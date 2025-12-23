using UnityEngine;

public class ShootingItem : MonoBehaviour
{
    public float speed = 15f;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Set the direction of the bullet
    public void SetDirection(Vector2 direction)
    {
        rb.velocity = direction.normalized * speed;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) return; // ignore player

        if (collision.CompareTag("Enemy"))
        {
            // Call TakeHit directly
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeHit();
            }

            Destroy(gameObject); // Destroy bullet
        }
    }
}
