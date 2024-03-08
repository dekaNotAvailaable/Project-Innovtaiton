using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{
    public SoundEffects soundEffects;
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
        if (soundEffects != null)
        {
            soundEffects.ButtonSoundPlay();
            Invoke("LoadSceneDelay", soundEffects.ButtonSoundLength());
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