using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{
    public void NextScene(string scene)
    {
        SceneManager.LoadSceneAsync(scene);
    }
}