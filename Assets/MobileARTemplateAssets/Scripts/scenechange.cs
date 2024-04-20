using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{
    private string nextScene;
    private CameraController camControl;
    private void Start()
    {
        camControl = FindAnyObjectByType<CameraController>();
    }
    public void NextScene(string scene)
    {
        nextScene = scene;
        if (camControl != null)
        {
            camControl.ToggleCamera();
        }
        if (SoundEffects.Instance != null)
        {
            SoundEffects.Instance.ButtonSoundPlay();
            Invoke("LoadSceneDelay", SoundEffects.Instance.ButtonSoundLength());
        }
        else
        {
            SceneManager.LoadSceneAsync(scene);
        }


        // else { SceneManager.LoadSceneAsync(scene); }
    }
    private void LoadSceneDelay()
    {
        SceneManager.LoadSceneAsync(nextScene);
    }
}