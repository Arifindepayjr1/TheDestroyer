using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 1;
    public float lifeTime = 2f;

    private int direction;

    public void SetDirection(int dir)
    {
        direction = dir;
    }

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.Translate(Vector2.right * direction * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyHealth>()?.TakeDamage(damage);

            // Find the player and add a stack
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStack>()?.AddStack(1);

            Destroy(gameObject);
        }
    }
}
