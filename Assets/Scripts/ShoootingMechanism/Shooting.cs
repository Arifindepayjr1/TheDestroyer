using UnityEngine;

public class Shooting : MonoBehaviour
{
    [Header("References")]
    public GameObject bulletPrefab;       // Bullet prefab
    public Transform firePoint;           // FirePoint in front of player

    [Header("Shooting Settings")]
    public bool canShoot = true;
    public float fireRate = 0.3f;         // Time between shots

    private float nextFireTime = 0f;

    void Update()
    {
        // Continuous shooting while holding Space
        if (Input.GetKey(KeyCode.Space) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        if (!canShoot) return;

        // Spawn bullet at firePoint
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Determine direction based on player facing
        ShootingItem bulletScript = bullet.GetComponent<ShootingItem>();
        if (bulletScript != null)
        {
            Vector2 shootDirection = transform.localScale.x > 0 ? Vector2.right : Vector2.left;
            bulletScript.SetDirection(shootDirection);
        }
        else
        {
            Debug.LogError("ShootingItem script missing on bullet prefab!");
        }

        // Auto-destroy after 3 seconds
        Destroy(bullet, 3f);
    }
}
