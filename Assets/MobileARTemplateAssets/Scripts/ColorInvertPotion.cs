using System.Collections;
using UnityEngine;

public class ColorInvertPotion : MonoBehaviour
{
    private ColorDetection colorDetect;
    public float inversionDuration = 2f;
    private void Start()
    {
        colorDetect = FindAnyObjectByType<ColorDetection>();
    }
    public void ApplyColorInversion()
    {
        StartCoroutine(InvertColorOverTime());
    }
    private IEnumerator InvertColorOverTime()
    {
        Color initialColor = colorDetect.pixelColor;
        Color invertedColor = new Color(1 - initialColor.r, 1 - initialColor.g, 1 - initialColor.b, initialColor.a);
        colorDetect.pixelColor = invertedColor;
        Debug.Log("detected color :" + initialColor + " inverted:" + invertedColor + " raw value:" + colorDetect.pixelColor);
        yield return new WaitForSeconds(inversionDuration);
        colorDetect.pixelColor = initialColor;
    }
}
