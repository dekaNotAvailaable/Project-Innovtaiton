using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{
    public SoundEffects soundEffects;
    private string nextScene;
    public void NextScene(string scene)
    {
        nextScene = scene;
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