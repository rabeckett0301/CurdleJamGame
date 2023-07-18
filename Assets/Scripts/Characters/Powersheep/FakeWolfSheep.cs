using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeWolfSheep : BaseSheep
{
    [SerializeField] float range;
    [SerializeField] LayerMask scareableMask;

    private void FixedUpdate()
    {
        CheckForSheep();
    }

    void CheckForSheep()
    {
        ContactFilter2D contactFilter2D = new();
        contactFilter2D.SetLayerMask(scareableMask);
        Collider2D[] results = new Collider2D[5];
        Physics2D.OverlapCircle(transform.position, range, contactFilter2D, results);

        if (!results[0])
        {
            return;
        }

        foreach (Collider2D hit in results)
        {
            if (hit == null)
            {
                return;
            }

            SheepMovement sheepMovement = hit.gameObject.GetComponent<SheepMovement>();

            if(sheepMovement.movementDirection == MovementDirection.LEFT)
            {
                sheepMovement.SetMovementDirection(MovementDirection.RIGHT);
            }
            else
            {
                sheepMovement.SetMovementDirection(MovementDirection.LEFT);
            }
        }
    }
}
