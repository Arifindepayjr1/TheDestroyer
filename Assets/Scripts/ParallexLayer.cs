using UnityEngine;

public class ParallaxLayer : MonoBehaviour
{
    [Range(0f, 1f)]
    public float parallaxStrength;

    private Transform cam;
    private Vector3 startPos;

    void Start()
    {
        cam = Camera.main.transform;
        startPos = transform.position;
    }

    void LateUpdate()
    {
        float camX = cam.position.x;
        transform.position = new Vector3(
            startPos.x + camX * parallaxStrength,
            startPos.y,
            startPos.z
        );
    }
}
