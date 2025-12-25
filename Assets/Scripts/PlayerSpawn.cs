using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    // Static variable persists across scene loads
    public static Vector2 nextSpawnPosition;
    public static bool useSpawnPosition = false;

    void Start()
    {
        if (useSpawnPosition)
        {
            transform.position = nextSpawnPosition;
            useSpawnPosition = false; // Reset
        }
    }
}
