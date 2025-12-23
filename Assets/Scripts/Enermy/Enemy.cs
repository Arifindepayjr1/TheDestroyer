using UnityEngine;

public class Enemy : MonoBehaviour
{
    public void TakeHit()
    {
        // Here you can add effects, health reduction, etc.
        Destroy(gameObject); // destroy enemy
    }
}
