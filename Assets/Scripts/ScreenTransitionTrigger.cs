using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionTrigger : MonoBehaviour
{
    public string sceneToLoad;      // Next scene name
    public Vector2 spawnPosition;   // Where the player appears in the next scene

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Store spawn position using a static variable
            PlayerSpawn.nextSpawnPosition = spawnPosition;

            // Load the next scene
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
