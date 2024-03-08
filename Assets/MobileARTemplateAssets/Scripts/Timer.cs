using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{

    public TextMeshProUGUI timerText;
    public float timeLimit = 120f;
    private float currentTime;
    public bool YEStimer;

    private void Start()
    {
        if (YEStimer)
        {
            currentTime = timeLimit;
            UpdateTimerText();
            float textWidth = timerText.preferredWidth;
            Vector3 newPosition = new Vector3(Screen.width / 2f + textWidth / 2f, timerText.rectTransform.position.y, 0f);
            timerText.rectTransform.position = newPosition;
        }
        else { timerText.gameObject.SetActive(false); }
    }

    private void Update()
    {
        currentTime -= Time.deltaTime;
        UpdateTimerText();
        if (currentTime <= 0f)
        {
            Debug.Log("Time's up!");
            currentTime = 0f;
        }
    }
    private void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
