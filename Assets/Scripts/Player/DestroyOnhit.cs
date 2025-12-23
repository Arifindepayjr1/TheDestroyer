using UnityEngine;

public class DestroyOnHit : MonoBehaviour
{
    // Call this when the enemy is hit
    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}

