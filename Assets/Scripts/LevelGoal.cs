using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelGoal : MonoBehaviour
{
    [Header("Settings")]
    public string nextSceneName;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // 1. Reset the save point
            if (GameManager.instance != null)
            {
                GameManager.instance.hasSavePoint = false;
            }

            // 2. Call the function that uses the Inspector variable
            LoadNextLevel();
        }
    }

    void LoadNextLevel()
    {
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            // USE THE VARIABLE NAME, NOT "TEXT IN QUOTES"
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.LogError("Next Scene Name is missing in the Inspector of " + gameObject.name);
        }
    }
}