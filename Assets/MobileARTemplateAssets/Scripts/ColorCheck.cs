using TMPro;
using UnityEngine;

public class ColorCheck : MonoBehaviour
{
    [HideInInspector]
    public int colorIndex;
    PoitionColor poitionColor;
    ColorDetection colorDetection;
    public TextMeshProUGUI debugText;

    void Start()
    {
        poitionColor = FindObjectOfType<PoitionColor>();
        colorDetection = FindObjectOfType<ColorDetection>();
        debugText.gameObject.SetActive(false);
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
    bool ColorApproximatelyEqual(Color color1, Color color2)
    {
        float tolerance = 0.25f;
        bool redMatch = Mathf.Abs(color1.r - color2.r) <= tolerance;
        bool greenMatch = Mathf.Abs(color1.g - color2.g) <= tolerance;
        bool blueMatch = Mathf.Abs(color1.b - color2.b) <= tolerance;
        return redMatch && greenMatch && blueMatch;
    }
}
