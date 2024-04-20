using UnityEngine;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour
{
    public Image crossHair;
    public RawImage CameraDisplayRawImage;

    void Start()
    {
        PositionCrosshairAtPixelCenter();
    }

    void PositionCrosshairAtPixelCenter()
    {
        // Get the dimensions of the crosshair image and the raw image
        float crossHairWidth = crossHair.rectTransform.rect.width;
        float crossHairHeight = crossHair.rectTransform.rect.height;
        float rawImageWidth = CameraDisplayRawImage.rectTransform.rect.width;
        float rawImageHeight = CameraDisplayRawImage.rectTransform.rect.height;

        // Calculate the position of the crosshair at the center of the raw image
        float crossHairX = CameraDisplayRawImage.rectTransform.position.x;
        float crossHairY = CameraDisplayRawImage.rectTransform.position.y;

        // Offset the position to the center of the raw image
        crossHairX -= (rawImageWidth / 2f) - (crossHairWidth / 2f);
        crossHairY += (rawImageHeight / 2f) - (crossHairHeight / 2f);

        // Set the position of the crosshair
        crossHair.rectTransform.position = new Vector3(crossHairX, crossHairY, 0f);
    }
}
