using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public Transform target;
    public Vector3 offset;
    public PlayerSide side;

    void Start() {
        transform.position = target.position + offset;
        transform.LookAt(target, Vector3.up);

        var myCamera = GetComponent<Camera>();
        myCamera.pixelRect = GetPixelRect();
    }

    Rect GetPixelRect() {
        int width = Screen.width / 2;
        int height = Screen.height;
        
        var targetRect = new Rect(0, 0, width, height);

        if (side == PlayerSide.Right) {
            targetRect.x = width;
        }

        return targetRect;
    }

    void Update() {
        transform.position = target.position + offset;
    }
}
