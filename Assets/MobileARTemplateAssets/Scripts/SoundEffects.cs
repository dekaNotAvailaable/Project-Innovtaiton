using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public AudioSource buttonSound;
    public AudioSource shutterSound;
    public AudioSource potionFound;
    public AudioSource shieldSound;
    private void Start()
    {
        if (shieldSound != null)
        {
            shieldSound.loop = true;
        }
        if (potionFound != null)
        {
            potionFound.volume = 1.0f;
        }
        if (shutterSound != null)
        {
            shutterSound.volume = 1.0f;
        }
    }
    public void shieldSoundPlay()
    {
        if (shieldSound != null)
        {
            shieldSound.Play();
        }
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
        if (buttonSound != null)
        {
            buttonSound.volume = 1.0f;
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
