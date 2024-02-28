using UnityEngine;

public class ColorCheck : MonoBehaviour
{
    [HideInInspector]
    public int colorIndex;
    Color[] detectedColors;
    PoitionColor poitionColor;
    ColorDetection colorDetection;
    // Start is called before the first frame update
    void Start()
    {
        poitionColor = FindAnyObjectByType<PoitionColor>();
        colorDetection = FindAnyObjectByType<ColorDetection>();
    }
    public void CheckColor()
    {


    }
    // Update is called once per frame
    void Update()
    {

        Debug.Log(poitionColor.GetPotionColor(2) + "poition");
    }
}
