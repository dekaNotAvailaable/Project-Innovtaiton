using UnityEngine;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour
{
    public Image crossHair;
    public RawImage rawImage;
    void Start()
    {
        crossHair.rectTransform.position = new Vector3(rawImage.texture.width / 2f, rawImage.texture.height / 2f, 0f);
        Debug.Log("raw Image width:" + rawImage.texture.width + "height:" + rawImage.texture.height);
    }
}
