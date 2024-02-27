using UnityEngine;

public class ColorDetection : MonoBehaviour
{
    // Start is called before the first frame update
    public Texture2D texture;
    [HideInInspector]
    public Color pixelColor;
    private void Awake()
    {
    }
    private void Start()
    {
        pixelColor = ReadPixel(texture.width / 2, texture.height / 2);
        RGBAToHSVConverter.RGBAtoHSV(pixelColor);
        Debug.Log("Pixel color at (texture.width/2, texute.height/2): " + pixelColor);
    }
    Color ReadPixel(int x, int y)
    {
        if (texture != null && x >= 0 && x < texture.width && y >= 0 && y < texture.height)
        {
            return texture.GetPixel(x, y);
        }
        else
        {
            Debug.LogError("Invalid pixel coordinates or texture is not assigned.");
            return Color.clear;
        }
    }

}

