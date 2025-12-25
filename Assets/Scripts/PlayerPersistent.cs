using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPersistant : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameObject instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this.gameObject;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // If a player already exists in the game, 
            // destroy the "new" one immediately!
            Destroy(gameObject);
        }
    }
}
