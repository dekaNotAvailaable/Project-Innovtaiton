using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public AudioSource buttonSound;
    public AudioSource shutterSound;
    public AudioSource potionFound;
    public AudioSource shieldSoundPart1;
    public AudioSource shieldSoundPart2;
    private void Start()
    {
        shieldSoundPart1.loop = true;
        potionFound.volume = 1.0f;
        shutterSound.volume = 1.0f;
    }
    public void shieldSoundPlay(bool value)
    {
        if (value)
        {
            shieldSoundPart1.Play();
        }
        else
        {
            shieldSoundPart1.Stop();
            shieldSoundPart2.Play();
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
