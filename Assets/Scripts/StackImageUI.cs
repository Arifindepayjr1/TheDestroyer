using UnityEngine;
using UnityEngine.UI;

public class StackImagesUI : MonoBehaviour
{
    public PlayerStack playerStack;   // Reference to PlayerStack
    public Image[] stackImages;       // UI Images for each stack
    public Sprite filledSprite;       // Blue stack
    public Sprite emptySprite;        // Gray stack

    void Update()
    {
        if (playerStack == null || stackImages.Length == 0) return;

        for (int i = 0; i < stackImages.Length; i++)
        {
            if (i < playerStack.currentStacks)
                stackImages[i].sprite = filledSprite;  // Filled
            else
                stackImages[i].sprite = emptySprite;   // Empty
        }
    }
}
