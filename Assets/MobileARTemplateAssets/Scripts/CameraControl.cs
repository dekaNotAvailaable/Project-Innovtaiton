using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public RawImage cameraDisplay;
    private WebCamTexture webcamTexture;
    [HideInInspector]
    public int photoIndex;
    ColorDetection colorDetection;
    void Start()
    {
        colorDetection = FindAnyObjectByType<ColorDetection>();
        cameraDisplay.gameObject.SetActive(false);
        if (WebCamTexture.devices.Length > 0)
        {
            webcamTexture = new WebCamTexture();
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
        if (webcamTexture.isPlaying)
        {
            webcamTexture.Stop();
            cameraDisplay.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogError(" camera start.");
            webcamTexture.Play();
            cameraDisplay.gameObject.SetActive(true);
        }
    }
    public void TakePhoto()
    {
        if (webcamTexture.isPlaying)
        {
            Texture2D photo = new Texture2D(webcamTexture.width, webcamTexture.height);
            photo.SetPixels(webcamTexture.GetPixels());
            photo.Apply();
            byte[] bytes = photo.EncodeToPNG();
            System.IO.File.WriteAllBytes(Application.persistentDataPath + "/photo.png", bytes);
            Debug.LogError("Photo saved.");
        }
        else
        {
            Debug.LogError("Camera is not active.");
        }
    }
    public void AnalyzeLastPhoto()
    {
        colorDetection.AnalyzePixelColorAtCenter();
    }
}

