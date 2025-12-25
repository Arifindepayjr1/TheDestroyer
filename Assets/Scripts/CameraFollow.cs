using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    [Header("Follow Settings")]
    public float damping = 0.3f;        // Higher = slower/smoother catch-up
    public Vector3 offset = new Vector3(0, 2, -10);

    [Header("Look Ahead")]
    public float lookAheadDistance = 4f;
    public float lookAheadSpeed = 2f;   // How fast the offset shifts

    private Vector3 velocity = Vector3.zero;
    private float currentLookAhead;

    void Start()
    {
        if (target == null)
            target = GameObject.FindGameObjectWithTag("Player").transform;

        transform.position = target.position + offset;
    }

    void LateUpdate()
    {
        if (target == null) return;

        // 1. Determine looking direction based on Player movement
        float moveInput = Input.GetAxisRaw("Horizontal");
        if (moveInput > 0)
            currentLookAhead = Mathf.Lerp(currentLookAhead, lookAheadDistance, Time.deltaTime * lookAheadSpeed);
        else if (moveInput < 0)
            currentLookAhead = Mathf.Lerp(currentLookAhead, -lookAheadDistance, Time.deltaTime * lookAheadSpeed);

        // 2. Calculate the target position
        Vector3 targetPosition = target.position + offset + (Vector3.right * currentLookAhead);

        // 3. SmoothDamp for the "Damping" effect
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, damping);
    }
}