using UnityEngine;

public class CameraFollowClamp : MonoBehaviour
{
    public Transform target;          // Player
    public float smoothSpeed = 5f;    // Smooth follow
    public float minX;                // Left boundary of map
    public float maxX;                // Right boundary of map

    private Vector3 offset;           // Keep camera Z offset

    void Start()
    {
        offset = transform.position - target.position;
    }

    void LateUpdate()
    {
        Vector3 desiredPos = new Vector3(target.position.x + offset.x, transform.position.y, transform.position.z);

        // Clamp X to map boundaries
        desiredPos.x = Mathf.Clamp(desiredPos.x, minX, maxX);

        // Smooth follow
        transform.position = Vector3.Lerp(transform.position, desiredPos, smoothSpeed * Time.deltaTime);
    }
}
