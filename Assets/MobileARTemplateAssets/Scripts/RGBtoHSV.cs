using UnityEngine;

public class RGBAToHSVConverter : MonoBehaviour
{
    public static float hue;
    public static float saturation;
    public static float value;

    public static Color RGBAtoHSV(Color rgba)
    {
        float min = Mathf.Min(rgba.r, Mathf.Min(rgba.g, rgba.b));
        float max = Mathf.Max(rgba.r, Mathf.Max(rgba.g, rgba.b));
        float delta = max - min;
        float v = max;
        float s = max == 0 ? 0 : delta / max;
        float h;
        if (max == min)
        {
            h = 0;
        }
        else
        {
            if (max == rgba.r)
                h = (rgba.g - rgba.b) / delta + (rgba.g < rgba.b ? 6 : 0);
            else if (max == rgba.g)
                h = (rgba.b - rgba.r) / delta + 2;
            else
                h = (rgba.r - rgba.g) / delta + 4;
            h /= 6;
        }
        hue = h;
        saturation = s;
        value = v;
        Debug.Log("Hue (H): " + hue + "Saturation (S): " + saturation + "Value (V): " + value);
        return new Color(hue, saturation, value);
    }
}
