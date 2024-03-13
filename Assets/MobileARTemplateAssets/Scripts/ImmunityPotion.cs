using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class ImmunityPotion : MonoBehaviour
{
    private bool immunityActive = false;
    public Image immuntyImage;
    public int immunitySec;

    // Method to apply immunity effect
    private void Start()
    {
        immuntyImage.gameObject.SetActive(false);
    }
    public void ApplyImmunity()
    {
        immunityActive = true;
        immuntyImage.gameObject.SetActive(true);
        Debug.Log("Immunity potion applied.");
        StartCoroutine(RemoveEffectAfterTime());
    }
    private IEnumerator RemoveEffectAfterTime()
    {
        yield return new WaitForSeconds(immunitySec);
        RemoveImmunity();
    }
    // Method to remove immunity effect
    private void RemoveImmunity()
    {
        immunityActive = false;
        Debug.Log("Immunity potion removed.");
    }

    // Method to check if immunity is active
    public bool IsImmunityActive()
    {
        return immunityActive;
    }
}
