using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepMovement : MonoBehaviour
{
    [SerializeField] MovementDirection movementDirection;

    [SerializeField] float movementSpeed;
    public float MovementSpeed { get { return movementSpeed; } private set { movementSpeed = value; } }
    float originalMovementSpeed;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalMovementSpeed = MovementSpeed;
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

    public IEnumerator ModifyMovement(float movementSpeedBonus)
    {
        MovementSpeed += movementSpeedBonus;
        yield return null;
        MovementSpeed = originalMovementSpeed;
    }
}

public enum MovementDirection
{
    LEFT,
    RIGHT
}
