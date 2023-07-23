using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringSheep : BaseSheep, IInteractable
{
    [SerializeField] StartMode startMode;
    [SerializeField] float bounceForce;
    [SerializeField] LayerMask bounceableMask;
    float cooldownBetweenBounces = 0.35f;
    bool canBounce = true;
    bool springMode = false;

    [Header("Audio clips")]
    [SerializeField] AudioClip[] idleSounds;
    [SerializeField] AudioClip[] boingSounds;
    [SerializeField] AudioClip springSound;

    private new void Start()
    {
        base.Start();

        InitializeSpringSheep();
    }

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
        audioSource.PlayOneShot(boingSounds[Random.Range(0, boingSounds.Length)]);
        audioSource.PlayOneShot(springSound);
        canBounce = false;
        yield return new WaitForSeconds(cooldown);
        canBounce = true;
    }

    public void Interact()
    {
        if (!HoldPoint)
        {
            springMode = !springMode;
            CanBeCarried = !springMode;
            animator.SetBool("SpringMode", springMode);
        }
    }

    public void PlayRandomIdleSound()
    {
        audioSource.PlayOneShot(idleSounds[Random.Range(0, idleSounds.Length)], 0.15f);
    }

    void InitializeSpringSheep()
    {
        if (startMode == StartMode.IDLE)
        {
            springMode = false;
            CanBeCarried = true;
        }
        else
        {
            springMode = true;
            CanBeCarried = false;
        }
        animator.SetBool("SpringMode", springMode);
    }
}

public enum StartMode
{
    IDLE,
    SPRING
}
