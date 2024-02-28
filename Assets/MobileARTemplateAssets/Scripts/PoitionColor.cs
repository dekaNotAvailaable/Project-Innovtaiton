using UnityEngine;
using UnityEngine.UI;

public class PoitionColor : MonoBehaviour
{
    public Image[] Potions;

    void Start()
    {
        ReassignPotionColors();
    }

    public void ReassignPotionColors()
    {
        foreach (Image potion in Potions)
        {
            if (potion != null)
            {
                Color randomColor = Random.ColorHSV();
                potion.color = randomColor;
                Debug.Log("Potion" + potion + " color changed to:" + randomColor);
            }
            else
            {
                Debug.LogWarning("Image component not found on a potion GameObject.");
            }
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
}
