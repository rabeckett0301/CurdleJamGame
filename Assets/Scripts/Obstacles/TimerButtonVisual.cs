using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerButtonVisual : MonoBehaviour
{
    [SerializeField] GameObject timerObject;
    Image timerFill;

    void Start()
    {
        TimerButton timerButton = GetComponentInParent<TimerButton>();
        timerFill = timerObject.GetComponentInChildren<Image>();

        timerButton.OnTimerStarted += TimerButton_OnTimerStarted;
        timerButton.OnTimerChanged += TimerButton_OnTimerChanged;
        timerButton.OnTimerEnded += TimerButton_OnTimerEnded;

        timerObject.SetActive(false);
    }

    private void TimerButton_OnTimerEnded(object sender, System.EventArgs e)
    {
        timerObject.SetActive(false);
    }

    private void TimerButton_OnTimerChanged(object sender, TimerButton.OnTimerChangedArgs e)
    {
        timerFill.fillAmount = (1- e.timeRemainingNormalized);
    }

    private void TimerButton_OnTimerStarted(object sender, System.EventArgs e)
    {
        timerObject.SetActive(true);
        timerFill.fillAmount = 1;
    }
}
