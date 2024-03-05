using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ColorCheck : MonoBehaviour
{
    [HideInInspector]
    public int colorIndex;
    PoitionColor poitionColor;
    ColorDetection colorDetection;
    public TextMeshProUGUI debugText;
    public TextMeshProUGUI percentageText;
    public float tolerance = 0.05f;

    void Start()
    {
        poitionColor = FindObjectOfType<PoitionColor>();
        colorDetection = FindObjectOfType<ColorDetection>();
        debugText.gameObject.SetActive(false);
        percentageText.gameObject.SetActive(false); // Hide percentage text initially
    }

    public void CheckColor()
    {
        Color detectedColor = colorDetection.pixelColor;
        Color closestPotionColor = GetClosestPotionColor(detectedColor);
        float matchPercentage = CalculateMatchPercentage(detectedColor, closestPotionColor);
        UpdatePercentageText(matchPercentage);

        Debug.Log(matchPercentage);

        for (int i = 0; i < poitionColor.Potions.Length; i++)
        {
            Color potionColor = poitionColor.GetPotionColor(i);
            if (ColorApproximatelyEqual(detectedColor, potionColor))
            {
                Debug.Log($"Detected color matches Potion {i + 1} color!");
                debugText.gameObject.SetActive(true);
                debugText.color = Color.green;
                debugText.text = $"Detected color matches Potion {i + 1} color!";
                poitionColor.DestroyPotions(i);
                return;
            }
        }

        debugText.gameObject.SetActive(true);
        Debug.Log("Detected color does not match any potion color.");
        debugText.color = Color.red;
        debugText.text = "Detected color does not match any potion color.";
    }

    Color GetClosestPotionColor(Color detectedColor)
    {
        Color closestColor = Color.white;
        float closestDistance = Mathf.Infinity;

        foreach (Image potion in poitionColor.Potions)
        {
            if (potion != null)
            {
                Color potionColor = potion.color;
                float distance = ColorDistance(detectedColor, potionColor);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestColor = potionColor;
                }
            }
        }
        return closestColor;
    }

    float CalculateMatchPercentage(Color detectedColor, Color closestPotionColor)
    {
        float distance = ColorDistance(detectedColor, closestPotionColor);
        float matchPercentage = Mathf.Clamp01(1 - (distance / tolerance));
        return matchPercentage * 100f; // Convert to percentage
    }

    void UpdatePercentageText(float matchPercentage)
    {
        if (percentageText != null)
        {
            percentageText.gameObject.SetActive(true);
            percentageText.text = $"{matchPercentage.ToString("F0")}%"; // Display percentage in text
        }
    }

    bool ColorApproximatelyEqual(Color color1, Color color2)
    {
        bool redMatch = Mathf.Abs(color1.r - color2.r) <= tolerance;
        bool greenMatch = Mathf.Abs(color1.g - color2.g) <= tolerance;
        bool blueMatch = Mathf.Abs(color1.b - color2.b) <= tolerance;
        return redMatch && greenMatch && blueMatch;
    }

    float ColorDistance(Color color1, Color color2)
    {
        float redDiff = Mathf.Abs(color1.r - color2.r);
        float greenDiff = Mathf.Abs(color1.g - color2.g);
        float blueDiff = Mathf.Abs(color1.b - color2.b);
        return (redDiff + greenDiff + blueDiff) / 3f;
    }
}
