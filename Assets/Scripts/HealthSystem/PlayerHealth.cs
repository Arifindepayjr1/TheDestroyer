using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public SpriteRenderer playerSr;
    public PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if(health <= 0)
        {
            playerSr.enabled = false;
            playerMovement.enabled = false;
        }
    }
}
