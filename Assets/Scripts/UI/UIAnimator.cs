using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAnimator : MonoBehaviour
{
    public Image Image;
    public List<Sprite> frames = new List<Sprite>();
    public float delay;

    private WaitForSecondsRealtime waitDelay;
    private int index = 0;

    private Coroutine coro;

    private void Awake()
    {
        waitDelay = new WaitForSecondsRealtime(delay);
    }

    private void OnEnable()
    {
        coro = StartCoroutine(ChangeFrames());
    }

    private void OnDisable()
    {
        StopCoroutine(coro);
    }

    public IEnumerator ChangeFrames()
    {
        while (true)
        {
            Image.overrideSprite = frames[index];
            yield return waitDelay;

            index++;

            if (index >= frames.Count)
            {
                index = 0;
            }
        }
    }
}
