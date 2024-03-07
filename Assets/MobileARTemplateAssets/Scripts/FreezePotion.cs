using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FreezePotion : MonoBehaviour
{
    public Image freezeImage;
    // Start is called before the first frame update
    // Duration to freeze input in seconds
    public float freezeDuration = 5f;
    Color transparent;

    // Method to start freezing input
    private void Start()
    {
        transparent = freezeImage.color;
        transparent.a = 0f;
        freezeImage.enabled = false;
        freezeImage.color = transparent;
    }
    private IEnumerator RemoveEffectAfterTime()
    {
        yield return new WaitForSeconds(freezeDuration);
        freezeImage.enabled = false;
    }
    public void ApplyFreezePotion()
    {
        freezeImage.enabled = true;
        freezeImage.DOFade(1f, freezeDuration)
          .OnComplete(() => StartCoroutine(RemoveEffectAfterTime()));

        StartCoroutine(RemoveEffectAfterTime());
    }
}
