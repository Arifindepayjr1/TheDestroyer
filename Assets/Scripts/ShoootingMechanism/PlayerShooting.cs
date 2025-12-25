using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject normalBulletPrefab;
    public GameObject powerBulletPrefab;
    public float fireRate = 0.25f;
    public float powerShotCooldown = 1.5f;

    float fireTimer;
    float powerTimer;

    int facingDirection = 1;
    float firePointOffsetX;

    PlayerStack stack;
    Animator animator;
    PlayerMovement playerMovement; // reference to movement

    void Start()
    {
        stack = GetComponent<PlayerStack>();
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        firePointOffsetX = Mathf.Abs(firePoint.localPosition.x);
    }

    void Update()
    {
        if (playerMovement != null && playerMovement.IsDead)
            return; // stop shooting if dead

        UpdateFacing();

        fireTimer -= Time.deltaTime;
        powerTimer -= Time.deltaTime;

        if (Input.GetMouseButtonDown(1) && CanPowerShot())
        {
            ShootPower();
            return;
        }

        if (Input.GetMouseButton(0) && fireTimer <= 0)
        {
            ShootNormal();
            fireTimer = fireRate;
        }
    }

    void UpdateFacing()
    {
        float move = Input.GetAxisRaw("Horizontal");
        if (move != 0)
        {
            facingDirection = (int)Mathf.Sign(move);
            firePoint.localPosition = new Vector3(
                firePointOffsetX * facingDirection,
                firePoint.localPosition.y,
                0
            );
        }
    }

    bool CanPowerShot()
    {
        return stack != null && stack.PowerShotReady && powerTimer <= 0;
    }

    void ShootNormal()
    {
        if (animator != null)
            animator.SetTrigger("Attack");

        GameObject bullet = Instantiate(normalBulletPrefab, firePoint.position, Quaternion.identity);
        bullet.GetComponent<PlayerBullet>().SetDirection(facingDirection);
    }

    void ShootPower()
    {
        if (animator != null)
            animator.SetTrigger("Attack");

        GameObject bullet = Instantiate(powerBulletPrefab, firePoint.position, Quaternion.identity);
        bullet.GetComponent<PlayerBullet>().SetDirection(facingDirection);

        stack.ResetStacks();
        powerTimer = powerShotCooldown;
    }
}
