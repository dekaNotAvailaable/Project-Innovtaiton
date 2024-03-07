using UnityEngine;

public class RGBAToHSVConverter : MonoBehaviour
{
    public static float hue;
    public static float saturation;
    public static float value;

    // Convert RGBA to HSV
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
        Debug.Log("Hue (H): " + hue + " Saturation (S): " + saturation + " Value (V): " + value);
        return new Color(hue, saturation, value);
    }

    // Convert HSV to RGBA
    public static Color HSVtoRGBA(Color hsv)
    {
        float h = hsv.r;
        float s = hsv.g;
        float v = hsv.b;

        float c = v * s;
        float x = c * (1 - Mathf.Abs((h * 6) % 2 - 1));
        float m = v - c;

        float r, g, b;
        if (h < 1f / 6f)
        {
            r = c;
            g = x;
            b = 0;
        }
        else if (h < 2f / 6f)
        {
            r = x;
            g = c;
            b = 0;
        }
        else if (h < 3f / 6f)
        {
            r = 0;
            g = c;
            b = x;
        }
        else if (h < 4f / 6f)
        {
            r = 0;
            g = x;
            b = c;
        }
        else if (h < 5f / 6f)
        {
            r = x;
            g = 0;
            b = c;
        }
        else
        {
            r = c;
            g = 0;
            b = x;
        }

        return new Color(r + m, g + m, b + m);
    }
}
