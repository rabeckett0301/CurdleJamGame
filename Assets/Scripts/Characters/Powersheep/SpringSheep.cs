using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringSheep : BaseSheep
{
    [SerializeField] float bounceForce;
    [SerializeField] LayerMask bounceableMask;
    float cooldownBetweenBounces = 0.35f;
    bool canBounce = true;
    int timesCalled;

    private void FixedUpdate()
    {
        if (HoldPoint || !canBounce)
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
            timesCalled++;
            Debug.Log(timesCalled);
            StartCoroutine(HandleCooldown(cooldownBetweenBounces));
        }
    }

    IEnumerator HandleCooldown(float cooldown)
    {
        canBounce = false;
        yield return new WaitForSeconds(cooldown);
        canBounce = true;
    }
}
