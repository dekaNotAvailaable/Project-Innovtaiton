using UnityEngine;
using UnityEngine.UI;

public class SaturationAdjustment : MonoBehaviour
{
    public Slider saturationSlider;
    public ColorDetection colorDetection;
    private Color originalColor;
    private ColorCheck colorCheck;

    private void Awake()
    {
        colorCheck = FindObjectOfType<ColorCheck>();
    }

    private void Start()
    {
        saturationSlider.value = 0.5f;
        saturationSlider.minValue = 0f;
        saturationSlider.maxValue = 1f;
        saturationSlider.onValueChanged.AddListener(AdjustSaturation);
        saturationSlider.onValueChanged.AddListener(delegate { colorCheck.CheckColor(); });
    }

    public void OriginalStoreColor()
    {
        originalColor = colorDetection.pixelColor;
    }

    private void AdjustSaturation(float value)
    {
        Color adjustedColor = AdjustColorSaturation(originalColor, value);
        colorDetection.pixelColor = adjustedColor;
        colorDetection.myScanedColor.color = adjustedColor;
    }

    private Color AdjustColorSaturation(Color originalColor, float saturationValue)
    {
        float h, s, v;
        Color.RGBToHSV(originalColor, out h, out s, out v);
        s = Mathf.Clamp01(saturationValue); // Clamp the new saturation value
        return Color.HSVToRGB(h, s, v);
    }
}
