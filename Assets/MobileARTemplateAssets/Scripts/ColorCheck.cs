using UnityEngine;

public class ColorCheck : MonoBehaviour
{
    [HideInInspector]
    public int colorIndex;
    PoitionColor poitionColor;
    ColorDetection colorDetection;

    void Start()
    {
        poitionColor = FindObjectOfType<PoitionColor>();
        colorDetection = FindObjectOfType<ColorDetection>();
    }

    public void CheckColor()
    {
        Color detectedColor = colorDetection.pixelColor;
        for (int i = 0; i < poitionColor.Potions.Length; i++)
        {
            Color potionColor = poitionColor.GetPotionColor(i);
            if (ColorApproximatelyEqual(detectedColor, potionColor))
            {
                Debug.Log($"Detected color matches Potion {i + 1} color!");
                return;
            }
        }
        Debug.Log("Detected color does not match any potion color.");
    }
    bool ColorApproximatelyEqual(Color color1, Color color2)
    {
        float tolerance = 0.05f;
        bool redMatch = Mathf.Abs(color1.r - color2.r) <= tolerance;
        bool greenMatch = Mathf.Abs(color1.g - color2.g) <= tolerance;
        bool blueMatch = Mathf.Abs(color1.b - color2.b) <= tolerance;
        return redMatch && greenMatch && blueMatch;
    }
}
