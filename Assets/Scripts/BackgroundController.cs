using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    private float startPosX;
    private Transform cam;

    [Range(0f, 1f)]
    public float parallaxEffect = 0.5f;

    void Start()
    {
        startPosX = transform.position.x;
        cam = Camera.main.transform;
    }

    void Update()
    {
        float distance = cam.position.x * parallaxEffect;
        transform.position = new Vector3(
            startPosX + distance,
            transform.position.y,
            transform.position.z
        );
        Debug.Log($"{gameObject.name} X = {transform.position.x}");
    }
}
