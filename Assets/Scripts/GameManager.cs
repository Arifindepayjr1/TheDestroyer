using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Vector2 lastSavePointPosition;
    public bool hasSavePoint = false;

    private GameObject player;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        player = GameObject.FindGameObjectWithTag("Player");

        GameObject spawnPoint = GameObject.Find("LevelStartPoint");

        if (player == null) return;

        if (hasSavePoint)
            player.transform.position = lastSavePointPosition;
        else if (spawnPoint != null)
            player.transform.position = spawnPoint.transform.position;
    }

    public void RespawnPlayer(GameObject playerObj)
    {
        if (hasSavePoint)
            playerObj.transform.position = lastSavePointPosition;
        else
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
