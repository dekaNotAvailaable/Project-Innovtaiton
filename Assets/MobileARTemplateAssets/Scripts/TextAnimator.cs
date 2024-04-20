using System.Collections;
using TMPro;
using UnityEngine;

public class TextAnimator : MonoBehaviour
{
    public TextMeshProUGUI findingText;
    public float animationSpeed = 0.5f;

    private bool isAnimating = false;

    private void Start()
    {
        findingText.enabled = false;
        Animate();
    }

    private IEnumerator AnimateText()
    {
        isAnimating = true;

        while (true)
        {
            findingText.text = "Connecting.";
            yield return new WaitForSeconds(animationSpeed);

            findingText.text = "Connecting..";
            yield return new WaitForSeconds(animationSpeed);

            findingText.text = "Connecting...";
            yield return new WaitForSeconds(animationSpeed);
        }
    }

    public void Animate()
    {
        findingText.enabled = true;
        if (!isAnimating)
        {
            StartCoroutine(AnimateText());
        }
    }
}
