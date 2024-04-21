using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class ImmunityPotion : MonoBehaviour
{
    private int _immunityPotion;
    public int ImmunityPotionInt
    {
        get { return _immunityPotion; }
        set
        {
            _immunityPotion = value;
            if (_immunityPotion > 0)
            {
                ShowButton();
            }
            else if (_immunityPotion <= 0)
            {
                HideButton();
            }
        }
    }
    private bool immunityActive = false;
    public Image immuntyImage;
    public Button immuntyButton;
    public int immunitySec;
    private void Start()
    {
        immuntyImage.gameObject.SetActive(false);
    }
    public void ApplyImmunity()
    {
        ImmunityPotionInt--;
        SoundEffects.Instance.shieldSoundPlay();
        immunityActive = true;
        immuntyImage.gameObject.SetActive(true);
        Debug.Log("Immunity potion applied.");
        StartCoroutine(RemoveEffectAfterTime());
    }
    private void ShowButton()
    {
        immuntyButton.gameObject.SetActive(true);
    }
    private void HideButton()
    {
        immuntyButton.gameObject.SetActive(false);
    }
    private IEnumerator RemoveEffectAfterTime()
    {
        yield return new WaitForSeconds(immunitySec);
        RemoveImmunity();
    }
    private void RemoveImmunity()
    {
        immunityActive = false;
        immuntyImage.gameObject.SetActive(false);
        Debug.Log("Immunity potion removed.");
    }
    public bool IsImmunityActive()
    {
        return immunityActive;
    }
}
