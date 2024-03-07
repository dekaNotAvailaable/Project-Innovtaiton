using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FreezePotion : MonoBehaviour
{
    public Image freezeImage;
    public float freezeDuration = 5f;
    Color transparent;
    private CameraController camControl;
    private void Start()
    {
        camControl = FindAnyObjectByType<CameraController>();
        transparent = freezeImage.color;
        transparent.a = 0f;
        freezeImage.enabled = false;
        freezeImage.color = transparent;
    }
    private IEnumerator RemoveEffectAfterTime()
    {
        yield return new WaitForSeconds(freezeDuration);
        freezeImage.enabled = false;
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
    public void ApplyFreezePotion()
    {
        freezeImage.enabled = true;
        camControl.WebCamTexturePlayer(1);
        StartCoroutine(IncreaseAlphaOverTime());
    }
}
