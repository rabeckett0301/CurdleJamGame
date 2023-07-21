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
        animator.SetBool("IsInflating", true);
        currentTime = 0;

        while(currentTime <= boostTime)
        {
            currentTime += Time.deltaTime;
            rb.velocity = new Vector2(0, boostForce);
            yield return null;
        }

        animator.SetBool("IsInflating", false);
    }
}
