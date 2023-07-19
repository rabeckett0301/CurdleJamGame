using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimerButton : MonoBehaviour
{
    public event EventHandler OnTimerStarted;
    public event EventHandler<OnTimerChangedArgs> OnTimerChanged;
    public event EventHandler OnTimerEnded;

    public class OnTimerChangedArgs : EventArgs
    {
        public float timeRemainingNormalized;
    }

    [SerializeField] GameObject objectToActivate;
    [SerializeField] float timeToDeactivate;
    float currentTime;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StopAllCoroutines();
        objectToActivate.GetComponent<IActivatable>().Activate();

        OnTimerStarted?.Invoke(this, EventArgs.Empty);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        StopAllCoroutines();
        StartCoroutine(StartTimer());
    }

    IEnumerator StartTimer()
    {
        currentTime = 0;

        while (currentTime <= timeToDeactivate)
        {
            currentTime += Time.deltaTime;
            Debug.Log((1 - (currentTime / timeToDeactivate)) * 100 + "% time remaining");

            OnTimerChanged?.Invoke(this, new OnTimerChangedArgs { timeRemainingNormalized = currentTime / timeToDeactivate });

            yield return null;
        }

        objectToActivate.GetComponent<IActivatable>().Deactivate();

        OnTimerEnded?.Invoke(this, EventArgs.Empty);
    }
}
