using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public AudioSource buttonSound;
    public AudioSource shutterSound;


    public void ShutterSound()
    {
        shutterSound.volume = 1.0f;
        if (shutterSound != null)
        {
            shutterSound.Play();
        }

    }
    public void ButtonSoundPlay()
    {
        buttonSound.volume = 1.0f;
        if (buttonSound != null)
        {
            buttonSound.Play();
        }
    }
    public float ButtonSoundLength()
    {
        if (buttonSound != null)
        {
            return buttonSound.clip.length;
        }
        else
        {
            return 0.0f;
        }
    }
}
