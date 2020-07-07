using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Player), typeof(Rigidbody))]
public class ShipMovement : MonoBehaviour {
    [Range(0.0f, 1000.0f)] public float speedMultiplier = 1;
    [Range(0.0f, 3000.0f)] public float horizontalSpeed = 1;

    Player player;
    Rigidbody rg;
    BoxCollider collider;

    void Start() {
        player = GetComponent<Player>();
        rg = GetComponent<Rigidbody>();
        collider = GetComponent<BoxCollider>();
    }

    void FixedUpdate() {
        if (!player.CanPlay) {
            rg.velocity = Vector3.zero;
            return;
        }

        float forwardVelocity = player.Speed * speedMultiplier * Time.fixedDeltaTime;
        float strafingVelocity = Input.GetAxis("Horizontal") * horizontalSpeed * Time.fixedDeltaTime;

        rg.velocity = transform.forward * forwardVelocity + transform.right * strafingVelocity;
    }

    public void RecalculateColliderBounds() {
        Vector3 origin = transform.position;
        var bounds = new Bounds();

        foreach (ShipPart part in player.parts) {
            Vector3 offset = origin - part.transform.position;
            Vector3 extents = part.meshRenderer.bounds.extents;
            bounds.Encapsulate(offset + extents);
            bounds.Encapsulate(offset - extents);
        }

        collider.size = bounds.size;
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * 5);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + transform.right * 5);

        // player = GetComponent<Player>();
        // collider = GetComponent<BoxCollider>();
        // RecalculateColliderBounds();
        // Gizmos.color = Color.red;
        // Gizmos.DrawWireCube(transform.position, collider.size);
    }
}