using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedSheep : BaseSheep
{
    [SerializeField] float range;
    [SerializeField] float speedBonus;
    [SerializeField] LayerMask speedableMask;

    private void FixedUpdate()
    {
        if (HoldPoint)
        {
            return;
        }

        TryForCollisions();
    }

    private void TryForCollisions()
    {
        ContactFilter2D contactFilter2D = new();
        contactFilter2D.SetLayerMask(speedableMask);
        Collider2D[] results = new Collider2D[10];
        Physics2D.OverlapCircle(transform.position, range, contactFilter2D, results);

        if (!results[0])
        {
            return;
        }

        foreach (Collider2D hit in results)
        { 
            if(hit == null)
            {
                return;
            }

            SheepMovement sheepMovement = hit.GetComponent<SheepMovement>();
            StartCoroutine(sheepMovement.ModifyMovement(speedBonus));
            animator.SetTrigger("IsBoosting");
        }
    }
}
