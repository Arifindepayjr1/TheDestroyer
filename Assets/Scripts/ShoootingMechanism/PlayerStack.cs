using UnityEngine;

public class PlayerStack : MonoBehaviour
{
    public int currentStacks = 0;
    public int maxStacks = 10;

    public bool PowerShotReady => currentStacks >= maxStacks;

    public void AddStack(int amount = 1)
    {
        currentStacks += amount;
        currentStacks = Mathf.Clamp(currentStacks, 0, maxStacks);

        Debug.Log("Stacks: " + currentStacks + " / " + maxStacks);
    }

    public void ResetStacks()
    {
        currentStacks = 0;
    }
}

