using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringSheep : BaseSheep, IInteractable
{
    [SerializeField] float bounceForce;
    [SerializeField] LayerMask bounceableMask;
    float cooldownBetweenBounces = 0.35f;
    bool canBounce = true;
    bool springMode = false;

    private void FixedUpdate()
    {
        if (HoldPoint || !canBounce || !springMode)
        {
            return;
        }

        TryForCollisions();
    }

   

    private void TryForCollisions()
    {
        ContactFilter2D contactFilter2D = new();
        contactFilter2D.SetLayerMask(bounceableMask);
        Collider2D[] results = new Collider2D[1];
        Physics2D.OverlapCircle(transform.position, 0.35f, contactFilter2D, results);

        if (!results[0])
        {
            return;
        }

        if (results[0].TryGetComponent(out Rigidbody2D rb))
        {
            rb.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
            StartCoroutine(HandleCooldown(cooldownBetweenBounces));
        }
    }

    IEnumerator HandleCooldown(float cooldown)
    {
        animator.SetTrigger("Bouncing");
        canBounce = false;
        yield return new WaitForSeconds(cooldown);
        canBounce = true;
    }

    public void Interact()
    {
        if (!HoldPoint)
        {
            springMode = !springMode;
            animator.SetBool("SpringMode", springMode);
        }
    }

    public override void Pickup(Transform holdPoint)
    {
        if (!springMode)
        {
            base.Pickup(holdPoint);
        }
    }
}
