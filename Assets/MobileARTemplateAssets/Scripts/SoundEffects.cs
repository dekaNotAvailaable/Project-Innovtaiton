using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public static SoundEffects Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public AudioSource buttonSound;
    public AudioSource shutterSound;
    public AudioSource potionFound;
    public AudioSource shieldSound;
    public AudioSource wrongColorBuzz;
    public AudioSource freezePotion;
    private void Start()
    {
        if (potionFound != null)
        {
            potionFound.volume = 1.0f;
        }
        if (shutterSound != null)
        {
            shutterSound.volume = 1.0f;
        }
    }
    public void WrongColorBuzz()
    {
        if (wrongColorBuzz != null)
        {
            wrongColorBuzz.Play();
        }
    }
    public void FreezePotionPlay()
    {
        if (freezePotion != null)
        {
            freezePotion.Play();
        }
    }
    public void ShieldSoundPlay()
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
