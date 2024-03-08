using UnityEngine;
using UnityEngine.UI;

public class PoitionColor : MonoBehaviour
{
    public Image[] Potions;
    private int activePotionCount; // Counter for active potions
    public Color[] potionColors;
    private SoundEffects effects;
    private bool isRunOnStart;

    void Start()
    {
        isRunOnStart = true;
        effects = FindAnyObjectByType<SoundEffects>();
        ReassignPotionColors();
        activePotionCount = Potions.Length; // Set initial active potion count
    }

    public void ReassignPotionColors()
    {
        if (isRunOnStart)
        {
            isRunOnStart = false;
        }
        else
        {
            effects.ButtonSoundPlay();
        }

        foreach (Image potion in Potions)
        {
            if (potion != null)
            {
                if (potionColors.Length > 0)
                {
                    // Get a random color from the predefined set of RGB colors
                    Color randomColor = potionColors[Random.Range(0, potionColors.Length)];
                    randomColor.a = 1;
                    potion.color = randomColor;
                    Debug.Log("Potion " + potion + " color changed to: " + randomColor);
                }
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
            effects.FoundPotionSound();
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
