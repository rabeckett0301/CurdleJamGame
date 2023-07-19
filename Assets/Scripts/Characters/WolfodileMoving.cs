using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfodileMoving : MonoBehaviour
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
        Physics2D.Raycast(transform.position, new Vector2(direction.x, 0f), contactFilter2D, result, 0.75f);

        if (result[0].collider != null)
        {
            if (moveDirection == MovementDirection.LEFT)
            {
                SetMovementDirection(MovementDirection.RIGHT);
            }
            else if (moveDirection == MovementDirection.RIGHT)
            {
                SetMovementDirection(MovementDirection.LEFT);
            }
        }
    }

    public void SetMovementDirection(MovementDirection directionToSet)
    {
        moveDirection = directionToSet;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //this needs to do stuff regarding the sheep count
        Debug.Log("Sheep eaten!");
        Destroy(collision.gameObject);
    }

    public void StartMovement()
    {
        awake = true;
    }
}
