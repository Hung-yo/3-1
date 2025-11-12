using UnityEngine;

public class TimerManager : MonoBehaviour
{
    public TMPro.TextMeshProUGUI timerText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timerText.text = "Time Remaining: " + GameManager.timeRemaining.ToString();
    }
}
