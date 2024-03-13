using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public AudioSource buttonSound;
    public AudioSource shutterSound;
    public AudioSource potionFound;
    //public AudioSource shieldSound;
    private void Start()
    {
        //shieldSound.loop = true;
        potionFound.volume = 1.0f;
        shutterSound.volume = 1.0f;
    }
    public void shieldSoundPlay()
    {
        //shieldSound.Play();
    }
    public void FoundPotionSound()
    {
        if (potionFound != null)
        {

            potionFound.Play();
        }
    }
    public void ShutterSound()
    {

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
