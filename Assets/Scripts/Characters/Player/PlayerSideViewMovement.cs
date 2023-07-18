using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSideViewMovement : MonoBehaviour
{
    ksSpace keyStateSpace;

    [SerializeField] float speed;
    [SerializeField] float jumpForce;

    public LookDirection lookDirection;

    bool hasJumped;
    Rigidbody2D rb;
    Vector2 spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new (Input.GetAxis("Horizontal") * speed, rb.velocity.y);

        if(Input.GetAxis("Horizontal") < 0)
        {
            lookDirection = LookDirection.LEFT;
        }
        else if(Input.GetAxis("Horizontal") > 0)
        {
            lookDirection = LookDirection.RIGHT;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            keyStateSpace = ksSpace.Down;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            keyStateSpace = ksSpace.Up;
        }
    }

    private void FixedUpdate()
    {
        if(keyStateSpace == ksSpace.Down && !hasJumped)
        {
            Jump();
            hasJumped = true;
        }
        else
        {

        }
    }

    private void Jump()
    {
        rb.velocity = Vector2.zero;
        rb.velocity = new Vector2(0, jumpForce);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 direction = collision.transform.position - transform.position;

        //check whether the collision was with the ground
        if(direction.y < 0)
        {
            hasJumped = false;
        }
    }

    public void ReturnToStartPosition()
    {
        rb.position = spawnPoint;
    }
}

public enum ksSpace
{
    Up,
    Down,
    Held
}

public enum LookDirection
{
    LEFT,
    RIGHT
}