using UnityEngine;
using UnityEngine.UI;

public class PoitionColor : MonoBehaviour
{
    public Image[] Potions;
    private int activePotionCount; // Counter for active potions

    void Start()
    {
        ReassignPotionColors();
        activePotionCount = Potions.Length; // Set initial active potion count
    }

    public void ReassignPotionColors()
    {
        foreach (Image potion in Potions)
        {
            if (potion != null)
            {
                Color randomColor = Random.ColorHSV();
                potion.color = randomColor;
                Debug.Log("Potion " + potion + " color changed to: " + randomColor);
            }
            else
            {
                Debug.LogWarning("Image component not found on a potion GameObject.");
            }
        }
    }

    public void DestroyPotions(int i)
    {
        if (Potions != null && i >= 0 && i < Potions.Length)
        {
            Destroy(Potions[i].gameObject);
            activePotionCount--; // Decrement active potion count
            Debug.Log("Potion " + i + " destroyed. Active potions remaining: " + activePotionCount);
        }
        else
        {
            Debug.LogWarning("Invalid potion index provided.");
        }
    }

    // Method to get the color of a specific potion
    public Color GetPotionColor(int potionIndex)
    {
        if (potionIndex >= 0 && potionIndex < Potions.Length)
        {
            return Potions[potionIndex].color;
        }
        else
        {
            Debug.LogWarning("Invalid potion index provided.");
            return Color.white; // Return default color
        }
    }

    // Method to get the number of active potions
    public int GetActivePotionCount()
    {
        return activePotionCount;
    }
}
