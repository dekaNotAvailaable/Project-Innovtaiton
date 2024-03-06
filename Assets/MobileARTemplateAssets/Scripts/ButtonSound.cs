using UnityEngine;
using UnityEngine.UI;

public class ButtonPressDetector : MonoBehaviour
{
    public AudioSource buttonClick;
    private Button button;

    private void Start()
    {
        // Get the Button component attached to this GameObject
        button = GetComponent<Button>();
        buttonClick.volume = 1.0f;

        // Add a listener for the button click event
        button.onClick.AddListener(ButtonClicked);
    }

    private void ButtonClicked()
    {
        buttonClick.Play();
        Debug.Log("Button Pressed!");
        // You can put any logic you want to execute when the button is pressed here
    }
}
