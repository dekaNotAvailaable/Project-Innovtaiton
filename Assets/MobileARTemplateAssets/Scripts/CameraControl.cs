using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public RawImage cameraDisplay;
    private WebCamTexture webcamTexture;
    private SoundEffects soundEffects;
    private bool cameraActive;
    [HideInInspector]
    public int photoIndex;
    ColorDetection colorDetection;
    ColorCheck colorCheck;
    SaturationAdjustment saturationAdjustment;
    public AspectRatioFitter fitter;
    void Start()
    {
        soundEffects = FindAnyObjectByType<SoundEffects>();
        saturationAdjustment = FindAnyObjectByType<SaturationAdjustment>();
        colorDetection = FindAnyObjectByType<ColorDetection>();
        colorCheck = FindAnyObjectByType<ColorCheck>();
        if (WebCamTexture.devices.Length > 0)
        {
            webcamTexture = new WebCamTexture(Screen.width, Screen.height);
            cameraDisplay.texture = webcamTexture;
            Debug.LogError("camera found on this device.");
            cameraActive = true;
            Debug.LogError(" camera start.");
            WebCamTexturePlayer(0);
            cameraDisplay.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogError("No camera found on this device.");
            cameraActive = false;
        }
        if (!webcamTexture.isPlaying)
        {
            WebCamTexturePlayer(0);
            cameraDisplay.gameObject.SetActive(true);
        }
    }
    public void WebCamTexturePlayer(int value)
    {
        if (value == 0)
        {
            webcamTexture.Play();
        }
        else if (value == 1)
        {
            webcamTexture.Pause();
        }
        else if (value == 2)
        {
            webcamTexture.Stop();
        }

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
            WebCamTexturePlayer(2);
            cameraDisplay.gameObject.SetActive(false);
        }
    }
    public void TakePhoto()
    {
        if (webcamTexture.isPlaying)
        {
            soundEffects.shutterSound.Play();
            Texture2D photo = new Texture2D(webcamTexture.width, webcamTexture.height);
            photo.SetPixels(webcamTexture.GetPixels());
            photo.Apply();
            byte[] bytes = photo.EncodeToPNG();
            System.IO.File.WriteAllBytes(Application.persistentDataPath + "/photo.png", bytes);
            AnalyzeLastPhoto();
            saturationAdjustment.OriginalStoreColor();
            saturationAdjustment.saturationSlider.value = 0.5f;
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
