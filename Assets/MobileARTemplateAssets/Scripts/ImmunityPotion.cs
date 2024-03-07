using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class ImmunityPotion : MonoBehaviour
{
    private bool immunityActive = false;
    public Image immuntyImage;
    public int immunitySec;
    private SoundEffects soundEffects;
    private void Start()
    {
        soundEffects = FindAnyObjectByType<SoundEffects>();
        immuntyImage.enabled = false;
    }
    public void ApplyImmunity()
    {
        immunityActive = true;
        immuntyImage.enabled = true;
        soundEffects.shieldSoundPlay(true);
        Debug.Log("Immunity potion applied.");
        StartCoroutine(RemoveEffectAfterTime());
    }
    private IEnumerator RemoveEffectAfterTime()
    {
        yield return new WaitForSeconds(immunitySec);
        RemoveImmunity();
    }
    private void RemoveImmunity()
    {
        immunityActive = false;
        immuntyImage.enabled = false;
        Debug.Log("Immunity potion removed.");
        soundEffects.shieldSoundPlay(false);
    }
    public bool IsImmunityActive()
    {
        return immunityActive;
    }
}
