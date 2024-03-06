using UnityEngine;
using UnityEngine.UI;

public class SaturationAdjustment : MonoBehaviour
{
    public Slider saturationSlider;
    public ColorDetection colorDetection;
    private Color originalColor;
    private float originalBrightness;
    private ColorCheck colorCheck;

    private void Awake()
    {
        colorCheck = FindAnyObjectByType<ColorCheck>();
    }
    private void Start()
    {
        saturationSlider.value = 0.5f;
        saturationSlider.onValueChanged.AddListener(AdjustSaturation);
        saturationSlider.onValueChanged.AddListener(delegate { colorCheck.CheckColor(); });
    }
    public void OrignalStoreColor()
    {
        originalColor = colorDetection.pixelColor;
        originalBrightness = originalColor.maxColorComponent;
    }

    private void AdjustSaturation(float value)
    {
        Color adjustedColor = AdjustColorSaturation(originalColor, value);
        colorDetection.pixelColor = adjustedColor;
        colorDetection.myScanedColor.color = adjustedColor;
    }

    private Color AdjustColorSaturation(Color originalColor, float saturationValue)
    {
        float newSaturation = Mathf.Clamp(saturationValue, 0f, 1f);
        float grayscale = originalColor.grayscale;
        Color adjustedColor = Color.Lerp(Color.gray * grayscale, originalColor, newSaturation);
        float brightnessMultiplier = originalBrightness / adjustedColor.maxColorComponent;
        adjustedColor *= brightnessMultiplier;
        adjustedColor.a = originalColor.a;
        return adjustedColor;
    }
}
