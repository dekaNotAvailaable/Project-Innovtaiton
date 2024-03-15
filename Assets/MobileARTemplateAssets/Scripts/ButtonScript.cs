using System.Collections;
using TMPro;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public TextMeshProUGUI findingText;
    public float animationSpeed = 0.5f; // Adjust this value to change the speed of the animation

    private bool isAnimating = false;

    private void Start()
    {
        findingText.enabled = false;
        ButtonAnimation();
    }

    private IEnumerator AnimateText()
    {
        isAnimating = true;

        while (true)
        {
            findingText.text = "finding.";
            yield return new WaitForSeconds(animationSpeed);

            findingText.text = "finding..";
            yield return new WaitForSeconds(animationSpeed);

            findingText.text = "finding...";
            yield return new WaitForSeconds(animationSpeed);
        }
    }

    public void ButtonAnimation()
    {
        findingText.enabled = true;
        if (!isAnimating)
        {
            StartCoroutine(AnimateText());
        }
    }
}
