using UnityEngine;

public class RGBAToHSVConverter : MonoBehaviour
{
    private void Start()
    {
        //Color rgbaColor = new Color(1f, 1f, 1f, 1.000f);
        //Color hsvColor = RGBAtoHSV(rgbaColor);

    }

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
        Debug.Log("Hue (H): " + h + "Saturation (S): " + s + "Value (V): " + v);
        return new Color(h, s, v);

    }
}
