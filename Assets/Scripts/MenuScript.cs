using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene switching

public class ButtonSceneLoader : MonoBehaviour
{
    // This function will be called by the button
    public void LoadOffWhiteScreen()
    {
        SceneManager.LoadScene("OffWhiteScreen"); // Make sure the name matches exactly
    }
}
