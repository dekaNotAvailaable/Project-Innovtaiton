using UnityEngine;

public class Crosshair : MonoBehaviour
{
    void Start()
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        rectTransform.position = new Vector3(Screen.width / 2f, Screen.height / 2f, 0f);
    }
}
