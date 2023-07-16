using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepMovement : MonoBehaviour
{
    [SerializeField] MovementDirection movementDirection;
    [SerializeField] float movementSpeed;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if(movementDirection == MovementDirection.LEFT)
        {
            rb.velocity = new (-1 * movementSpeed, rb.velocity.y);
        }
        else if(movementDirection == MovementDirection.RIGHT)
        {
            rb.velocity = new(1 * movementSpeed, rb.velocity.y);
        }
    }

    public void SetMovementDirection(MovementDirection directionToSet)
    {
        movementDirection = directionToSet;
    }
}

public enum MovementDirection
{
    LEFT,
    RIGHT
}
