using UnityEngine;

public class SavePoint : MonoBehaviour
{
    public Color activeColor = Color.green;
    public Color inactiveColor = Color.red;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = inactiveColor;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            ActivateSavePoint();
    }

    void ActivateSavePoint()
    {
        GameManager.instance.lastSavePointPosition = transform.position;
        GameManager.instance.hasSavePoint = true;

        spriteRenderer.color = activeColor;

        Debug.Log("Game Saved at: " + transform.position);
    }
}
