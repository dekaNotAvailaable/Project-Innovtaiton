using UnityEngine;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour
{
    public Image crossHair;
    public ColorDetection colorDetection;

    void Start()
    {
        PositionCrosshairAtPixelCenter();
    }

    void PositionCrosshairAtPixelCenter()
    {
        float crossHairHeight = crossHair.rectTransform.rect.height;
        float yOffset = crossHairHeight / 2f;
        crossHair.rectTransform.position = new Vector3(Screen.width / 2, Screen.height / 2 + (yOffset), 0f);
    }
}
