using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficSheep : BaseSheep, IInteractable
{
    GameObject firstStoppedSheep;
    int sheepStopped;
    [SerializeField] float incrementPerSheep;
    float originalRaycastRange;
    [SerializeField] float raycastRange;
    [SerializeField] LayerMask stoppableMask;

    private TrafficMode mode;


    private void FixedUpdate()
    {
        if (mode == TrafficMode.GO)
        {
            return;
        }

        if (!firstStoppedSheep)
        {
            CheckForFirstSheep();
        }
        else
        {
            CastRayAgainstFirstSheep();
        }
    }

    private void CheckForFirstSheep()
    {
        ContactFilter2D contactFilter2D = new();
        contactFilter2D.SetLayerMask(stoppableMask);
        Collider2D[] results = new Collider2D[1];
        Physics2D.OverlapCircle(transform.position, raycastRange / 2, contactFilter2D, results);

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

            originalRaycastRange = raycastRange;
            firstStoppedSheep = hit.gameObject;
            SheepMovement sheepMovement = hit.GetComponent<SheepMovement>();
            sheepMovement.ModifyMovement(-sheepMovement.MovementSpeed);
            sheepStopped++;
        }
    }

    private void CastRayAgainstFirstSheep()
    {
        ContactFilter2D contactFilter2D = new();
        contactFilter2D.SetLayerMask(stoppableMask);
        RaycastHit2D[] results = new RaycastHit2D[10];
        Vector2 direction = firstStoppedSheep.transform.position - transform.position;
        Physics2D.Raycast(transform.position, direction, contactFilter2D, results, raycastRange);

        sheepStopped = 0;

        foreach (RaycastHit2D hit in results)
        {
            if (!hit)
            {
                break;
            }

            SheepMovement sheepMovement = hit.collider.gameObject.GetComponent<SheepMovement>();
            StartCoroutine(sheepMovement.ModifyMovement(-sheepMovement.MovementSpeed));
            sheepStopped++;
            raycastRange = originalRaycastRange + (sheepStopped * incrementPerSheep);
        }
    }

    public void Interact()
    {
        if(mode == TrafficMode.GO)
        {
            mode = TrafficMode.STOP;
            GetComponentInChildren<SpriteRenderer>().color = Color.red;
        }
        else
        {
            mode = TrafficMode.GO;
            GetComponentInChildren<SpriteRenderer>().color = Color.green;
        }
    }
}

public enum TrafficMode
{
    STOP,
    GO
}
