using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class FreezePotion : MonoBehaviour
{
    private int _freezePotion;
    public int FreezePotionInt
    {
        get { return _freezePotion; }
        set
        {
            _freezePotion = value;
            if (_freezePotion > 0)
            {
                freezeButton.gameObject.SetActive(true);
            }
            else if (_freezePotion <= 0) { freezeButton.gameObject.SetActive(false); }
        }
    }
    public Image freezeImage;
    public float freezeDuration = 5f;
    public Button freezeButton;
    Color transparent;
    private CameraController camControl;
    private PlayerMutiplayerHandle MutiplayerHandle;
    private ImmunityPotion shield;
    private void Start()
    {
        camControl = FindAnyObjectByType<CameraController>();
        shield = FindAnyObjectByType<ImmunityPotion>();
        transparent = freezeImage.color;
        transparent.a = 0f;
        freezeImage.gameObject.SetActive(false);
        freezeImage.color = transparent;
    }
    private IEnumerator RemoveEffectAfterTime()
    {
        yield return new WaitForSeconds(freezeDuration);
        freezeImage.gameObject.SetActive(false);
        camControl.WebCamTexturePlayer(0);
    }
    private IEnumerator IncreaseAlphaOverTime()
    {
        float targetAlpha = 0.4313f;
        float duration = 4f;
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            float currentAlpha = Mathf.Lerp(0f, targetAlpha, elapsedTime / duration);
            Color newColor = freezeImage.color;
            newColor.a = currentAlpha;
            freezeImage.color = newColor;
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        Color finalColor = freezeImage.color;
        finalColor.a = targetAlpha;
        freezeImage.color = finalColor;
        StartCoroutine(RemoveEffectAfterTime());
    }
    public void SendSignalOnButtonClick()
    {
        MutiplayerHandle = FindAnyObjectByType<PlayerMutiplayerHandle>();
        if (MutiplayerHandle != null)
        {
            MutiplayerHandle.ActivateFreezePotionOnOtherClients();
        }
        else { Debug.Log("player profile info is null"); }
    }
    public void ApplyFreezePotion()
    {
        if (!shield.IsImmunityActive())
        {
            FreezePotionInt--;
            freezeImage.gameObject.SetActive(true);
            camControl.WebCamTexturePlayer(1);
            StartCoroutine(IncreaseAlphaOverTime());
        }
    }
}
