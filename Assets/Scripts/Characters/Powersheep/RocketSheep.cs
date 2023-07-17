using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketSheep : BaseSheep, IInteractable
{
    [SerializeField] float boostTime;
    [SerializeField] float boostForce;
    float currentTime;

    public void Interact()
    {
        if (!BeingCarried)
        {
            StartCoroutine(UseRocket());
        }
    }

    IEnumerator UseRocket()
    {
        while(currentTime <= boostTime)
        {
            currentTime += Time.deltaTime;
            rb.velocity = new Vector2(0, boostForce);
            yield return null;
        }
    }
}
