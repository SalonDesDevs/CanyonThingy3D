using UnityEngine;

public class Spike : MonoBehaviour {
    public Transform player;
    private float maxY = 0;
    private static readonly Vector3 added = new Vector3(0f, 0.02f, 0f);

    private void Start() {
        var transform1 = transform;
        var position = transform1.position;
        maxY = position.y;
        position -= new Vector3(0, 5, 0);
        transform1.position = position;
    }

    // Update is called once per frame
    void Update() {
        var distance = Vector3.Distance(player.position, transform.position);
        if (distance > 4 && transform.position.y < maxY) {
            transform.position += added;
        }
    }

    private void OnTriggerEnter(Collider other) {
        var player = other.gameObject.GetComponent<Player>();
        player.Damage(20, false);
    }
}