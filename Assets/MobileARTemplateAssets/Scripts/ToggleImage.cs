using UnityEngine;
using UnityEngine.UI;
public class ToggleImage : MonoBehaviour
{
    public Image ImageDisplayGameObject;
    public Sprite[] ImageToActive;
    private int ImageCount;
    private void Start()
    {
        ImageCount = PlayerPrefs.GetInt("CharacterInt");
        ShowImage();
    }
    private void ShowImage()
    {
        // Debug.Log(ImageCount + "/" + ImageToActive.Length);
        ImageDisplayGameObject.sprite = ImageToActive[ImageCount];
    }
    public void Minus()
    {
        SoundEffects.Instance.ButtonSoundPlay();
        ImageCount--;
        if (ImageCount < 0)
        {
            ImageCount = ImageToActive.Length - 1;
        }
        ShowImage();
    }

    public void Plus()
    {
        SoundEffects.Instance.ButtonSoundPlay();
        if (ImageCount < ImageToActive.Length - 1)
        {
            ImageCount++;
        }
        else
        {
            ImageCount = 0;
        }
        ShowImage();
    }
    public void SetCharacter()
    {
        SoundEffects.Instance.ButtonSoundPlay();
        PlayerPrefs.SetInt("CharacterInt", ImageCount);
        PlayerPrefs.Save();
    }

}
