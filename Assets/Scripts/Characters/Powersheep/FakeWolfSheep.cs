using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeWolfSheep : BaseSheep
{
    [SerializeField] float range;
    [SerializeField] LayerMask scareableMask;

    [SerializeField] AudioClip[] scareSounds;

    float cooldownTime = 0.3f;
    bool canScare = true;
    
    private void FixedUpdate()
    {
        if (canScare)
        {
            CheckForSheep();
        }
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

            Vector2 direction = hit.transform.position - transform.position;

            SheepMovement sheepMovement = hit.gameObject.GetComponent<SheepMovement>();

            if(direction.x < 0)
            {
                sheepMovement.SetMovementDirection(MovementDirection.LEFT);
                SetLastLookedLeft(true);
                animator.SetTrigger("IsScaring");
                
            }
            else
            {
                sheepMovement.SetMovementDirection(MovementDirection.RIGHT);
                SetLastLookedLeft(false);
                animator.SetTrigger("IsScaring");
            }

            StartCoroutine(HandleCooldownTime());
            audioSource.PlayOneShot(scareSounds[Random.Range(0, scareSounds.Length)]);
        }
    }

    IEnumerator HandleCooldownTime()
    {
        canScare = false;
        yield return new WaitForSeconds(cooldownTime);
        canScare = true;
    }
}
