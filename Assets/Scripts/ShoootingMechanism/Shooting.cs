using UnityEngine;

public class Shooting : MonoBehaviour
{
    [Header("References")]
    public GameObject bulletPrefab;
    public Transform firePoint;
    public PlayerMovement playerMovement; // reference to check if dead

    [Header("Shooting Settings")]
    public bool canShoot = true;
    public float fireRate = 0.3f;

    private float nextFireTime = 0f;

    void Update()
    {
        if (playerMovement != null && playerMovement.IsDead) return; // cannot shoot if dead

        if (Input.GetKey(KeyCode.Space) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        if (!canShoot) return;

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

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

        Destroy(bullet, 3f);
    }
}
