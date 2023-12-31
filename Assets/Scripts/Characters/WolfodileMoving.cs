using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfodileMoving : MonoBehaviour, IDestroySheep
{
    bool awake = false;

    [Header("Movement")]
    [SerializeField] MovementDirection moveDirection;
    [SerializeField] float movementSpeed;
    float originalMovementSpeed;

    [Header("Wall Mask")]
    [SerializeField] LayerMask wallMask;

    Vector2 direction;
    Rigidbody2D rb;
    Animator animator;

    [SerializeField] AudioClip[] eatingSounds;
    AudioSource audioSource;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        bool lookingLeft = (moveDirection == MovementDirection.LEFT);
        animator.SetBool("LookingLeft", lookingLeft);
    }

    public void FixedUpdate()
    {
        if (awake)
        {
            if (moveDirection == MovementDirection.LEFT)
            {
                direction = new(-1, rb.velocity.y);
            }
            else if (moveDirection == MovementDirection.RIGHT)
            {
                direction = new(1, rb.velocity.y);
            }

            rb.velocity = new(direction.x * movementSpeed, rb.velocity.y);

            TryForWallCollisions();
        }
    }

    void TryForWallCollisions()
    {
        ContactFilter2D contactFilter2D = new();
        contactFilter2D.SetLayerMask(wallMask);
        RaycastHit2D[] result = new RaycastHit2D[1];
        Physics2D.Raycast(transform.position, new Vector2(direction.x, 0f), contactFilter2D, result, 1f);

        if (result[0].collider != null)
        {
            if (moveDirection == MovementDirection.LEFT)
            {
                SetMovementDirection(MovementDirection.RIGHT);
                animator.SetBool("LookingLeft", false);
            }
            else if (moveDirection == MovementDirection.RIGHT)
            {
                SetMovementDirection(MovementDirection.LEFT);
                animator.SetBool("LookingLeft", true);
            }
        }
    }

    public void SetMovementDirection(MovementDirection directionToSet)
    {
        moveDirection = directionToSet;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent(out SheepEvents sheepToDestroy))
        {
            DestroyNPSheep(sheepToDestroy);
            audioSource.PlayOneShot(eatingSounds[Random.Range(0, eatingSounds.Length)], 0.5f);
            animator.SetTrigger("IsEating");
        }
    }

    public void DestroyNPSheep(SheepEvents sheepToDestroy)
    {
        sheepToDestroy.DestroySheep();
    }

    public void StartMovement()
    {
        awake = true;
        animator.SetTrigger("Awake");
    }
}
