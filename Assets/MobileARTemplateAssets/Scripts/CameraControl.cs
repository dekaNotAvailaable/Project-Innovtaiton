using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public RawImage cameraDisplay;
    private WebCamTexture webcamTexture;
    void Start()
    {
        cameraDisplay.gameObject.SetActive(false);
        // Check if the device has a camera
        if (WebCamTexture.devices.Length > 0)
        {
            // Access the device's camera
            webcamTexture = new WebCamTexture();

            // Display the camera feed on the RawImage component
            cameraDisplay.texture = webcamTexture;
            Debug.LogError("camera found on this device.");
        }
        else
        {
            Debug.LogError("No camera found on this device.");
        }
    }
    public void ToggleCamera()
    {
        // Toggle camera on/off
        if (webcamTexture.isPlaying)
        {
            // Stop capturing from the camera
            webcamTexture.Stop();
            cameraDisplay.gameObject.SetActive(false);
        }
        else
        {
            // Start capturing from the camera
            Debug.LogError(" camera start.");
            webcamTexture.Play();
            cameraDisplay.gameObject.SetActive(true);
        }
    }
    //void Update()
    //{
    //    // Adjust the rotation of the RawImage based on the device's orientation
    //    AdjustCameraRotation();
    //}

    //void AdjustCameraRotation()
    //{
    //    // Get the device's current orientation
    //    DeviceOrientation orientation = Input.deviceOrientation;

    //    // Adjust the rotation of the RawImage based on the orientation
    //    switch (orientation)
    //    {
    //        case DeviceOrientation.Portrait:
    //        cameraDisplay.rectTransform.localRotation = Quaternion.Euler(0f, 0f, -90f);
    //        break;
    //        case DeviceOrientation.PortraitUpsideDown:
    //        cameraDisplay.rectTransform.localRotation = Quaternion.Euler(0f, 0f, 90f);
    //        break;
    //        case DeviceOrientation.LandscapeLeft:
    //        cameraDisplay.rectTransform.localRotation = Quaternion.Euler(0f, 0f, 0f);
    //        break;
    //        case DeviceOrientation.LandscapeRight:
    //        cameraDisplay.rectTransform.localRotation = Quaternion.Euler(0f, 0f, 180f);
    //        break;
    //    }
}
}
