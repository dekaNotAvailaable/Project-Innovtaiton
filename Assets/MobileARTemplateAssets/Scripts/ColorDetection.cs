using UnityEngine;
using UnityEngine.UI;

public class ColorDetection : MonoBehaviour
{
    public Texture2D texture;
    [HideInInspector]
    public Color pixelColor;
    public Image myScanedColor;
    public void AnalyzePixelColorAtCenter()
    {
        byte[] imageData = System.IO.File.ReadAllBytes(Application.persistentDataPath + "/photo.png");
        Texture2D loadedTexture = new Texture2D(2, 2);
        loadedTexture.LoadImage(imageData);
        texture = loadedTexture;
        pixelColor = ReadPixel(texture.width / 2, texture.height / 2);
        RGBAToHSVConverter.RGBAtoHSV(pixelColor);
        Debug.Log("Pixel color at (texture.width/2, texute.height/2): " + pixelColor);
        myScanedColor.color = pixelColor;
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

