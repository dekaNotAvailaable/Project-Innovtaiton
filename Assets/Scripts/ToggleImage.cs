using UnityEngine;
using UnityEngine.UI;
public class ToggleImage : MonoBehaviour
{
    public Image ImageDisplayGameObject;
    public Sprite ImageToActive;
    public void ShowImage()
    {
        ImageDisplayGameObject.sprite = ImageToActive;
    }
}