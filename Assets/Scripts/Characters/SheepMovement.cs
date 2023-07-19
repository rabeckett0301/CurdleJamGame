using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepMovement : MonoBehaviour
{
    [SerializeField] public MovementDirection movementDirection;
    [SerializeField] float movementSpeed;
    [SerializeField] LayerMask wallMask;
    public float MovementSpeed { get { return movementSpeed; } private set { movementSpeed = value; } }
    float originalMovementSpeed;
    Vector2 direction;
    Rigidbody2D rb;
    Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        originalMovementSpeed = MovementSpeed;
    }

    private void FixedUpdate()
    {
        if (movementDirection == MovementDirection.LEFT)
        {
            direction = new(-1, rb.velocity.y);
            animator.SetBool("IsMovingLeft", true);
            animator.SetBool("IsMovingRight", false);
        }
        else if (movementDirection == MovementDirection.RIGHT)
        {
            direction = new(1, rb.velocity.y);
            animator.SetBool("IsMovingRight", true);
            animator.SetBool("IsMovingLeft", false);
        }

        rb.velocity = new(direction.x * movementSpeed, rb.velocity.y);

        TryForWallCollisions();
    }

    public void SetMovementDirection(MovementDirection directionToSet)
    {
        movementDirection = directionToSet;
    }

    public IEnumerator ModifyMovement(float movementSpeedBonus)
    {
        MovementSpeed += movementSpeedBonus;
        yield return null;
        MovementSpeed = originalMovementSpeed;
    }

    void TryForWallCollisions()
    {
        ContactFilter2D contactFilter2D = new();
        contactFilter2D.SetLayerMask(wallMask);
        RaycastHit2D[] result = new RaycastHit2D[1];
        Physics2D.Raycast(transform.position, new Vector2(direction.x, 0f), contactFilter2D, result, 0.75f);

        if (result[0].collider != null)
        {
            if (movementDirection == MovementDirection.LEFT)
            {
                SetMovementDirection(MovementDirection.RIGHT);
            }
            else if (movementDirection == MovementDirection.RIGHT)
            {
                SetMovementDirection(MovementDirection.LEFT);
            }
        }
    }
}

public enum MovementDirection
{
    LEFT,
    RIGHT
}
