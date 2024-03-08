using System.Collections;
using UnityEngine;

public class ColorInvertPotion : MonoBehaviour
{
    private ColorDetection colorDetect;
    public float inversionDuration = 2f;
    private ImmunityPotion ImmunityPotion;
    private bool isRevert = false;
    private void Start()
    {
        ImmunityPotion = FindAnyObjectByType<ImmunityPotion>();
        colorDetect = FindAnyObjectByType<ColorDetection>();
    }
    public void ApplyColorInversion()
    {
        if (!ImmunityPotion.IsImmunityActive())
        {
            StartCoroutine(InvertColorOverTime());
        }
    }
    private IEnumerator InvertColorOverTime()
    {
        isRevert = true;
        Color initialColor = colorDetect.pixelColor;
        Color invertedColor = new Color(1 - initialColor.r, 1 - initialColor.g, 1 - initialColor.b, initialColor.a);
        colorDetect.pixelColor = invertedColor;
        Debug.Log("detected color :" + initialColor + " inverted:" + invertedColor + " raw value:" + colorDetect.pixelColor);
        yield return new WaitForSeconds(inversionDuration);
        colorDetect.pixelColor = initialColor;
        isRevert = false;
    }
    //public void bool
    //{ 
    //   return
    //}
}
