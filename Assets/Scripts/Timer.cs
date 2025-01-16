using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float totalTime = 60f;
    public TextMeshProUGUI timerText;
    public GameManager gameManager;

    private float remainingTime;

    void Start()
    {
        ResetTimer();
    }

    void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;

            if (remainingTime < 0)
            {
                remainingTime = 0;
                TimerFinished();
            }

            if (timerText != null)
            {
                UpdateTimerDisplay();
            }

        }
    }

    private void TimerFinished()
    {
        if (gameManager != null)
        {
            gameManager.TimeRunsOut();
        }
    }

    private void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:0}:{1:00}", minutes, seconds);
    }

    public void ResetTimer()
    {
        remainingTime = totalTime;
        UpdateTimerDisplay();  
    }
}
