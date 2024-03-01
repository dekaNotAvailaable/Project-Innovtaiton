using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public RawImage cameraDisplay;
    private WebCamTexture webcamTexture;
    private bool cameraActive;
    [HideInInspector]
    public int photoIndex;
    ColorDetection colorDetection;
    public AspectRatioFitter fitter;
    void Start()
    {
        colorDetection = FindAnyObjectByType<ColorDetection>();
        colorCheck = FindAnyObjectByType<ColorCheck>();
        if (WebCamTexture.devices.Length > 0)
        {
            webcamTexture = new WebCamTexture(Screen.width, Screen.height);
            cameraDisplay.texture = webcamTexture;
            Debug.LogError("camera found on this device.");
            cameraActive = true;
            Debug.LogError(" camera start.");
            webcamTexture.Play();
            cameraDisplay.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogError("No camera found on this device.");
            cameraActive = false;
        }
        if (!webcamTexture.isPlaying)
        {
            webcamTexture.Play();
            cameraDisplay.gameObject.SetActive(true);
        }
        //ToggleCamera();

    }
    private void Update()
    {
        if (!cameraActive)
        {
            return;
        }
        float ratio = (float)webcamTexture.width / (float)webcamTexture.height;
        fitter.aspectRatio = ratio;
        float scaleY = webcamTexture.videoVerticallyMirrored ? -1 : 1;
        cameraDisplay.rectTransform.localScale = new Vector3(1f, scaleY, 1f);
        float orientation = -webcamTexture.videoRotationAngle;
        cameraDisplay.rectTransform.localEulerAngles = new Vector3(0, 0, orientation);
    }
    public void ToggleCamera()
    {
        if (webcamTexture.isPlaying)
        {
            webcamTexture.Stop();
            cameraDisplay.gameObject.SetActive(false);
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
            AnalyzeLastPhoto();
            colorCheck.CheckColor();
            Debug.LogError("Object color analyzed.");
        }
        else
        {
            Debug.LogError("Camera is not active.");
        }
    }
    private void AnalyzeLastPhoto()
    {
        colorDetection.AnalyzePixelColorAtCenter();
    }
}

