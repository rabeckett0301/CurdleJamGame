using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    ksSpace keyStateSpace;

    [SerializeField] float speed;
    [SerializeField] float jumpForce;

    [HideInInspector] public LookDirection lookDirection;

    bool hasJumped;
    Rigidbody2D rb;
    Vector2 spawnPoint;
    Animator animator;
    bool lastMovedLeft = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new(Input.GetAxis("Horizontal") * speed, rb.velocity.y);

        if (Input.GetAxis("Horizontal") < 0)
        {
            lookDirection = LookDirection.LEFT;
            animator.SetBool("IsMovingLeft", true);

            animator.SetBool("IsMovingRight", false);
            lastMovedLeft = true;
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            lookDirection = LookDirection.RIGHT;
            animator.SetBool("IsMovingRight", true);
            animator.SetBool("IsMovingLeft", false);
            lastMovedLeft = false;
        }
        else
        {
            animator.SetBool("IsMovingLeft", false);
            animator.SetBool("IsMovingRight", false);
        }

        animator.SetBool("LastMovedLeft", lastMovedLeft);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            keyStateSpace = ksSpace.Down;
            animator.SetBool("IsJumping", true);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            keyStateSpace = ksSpace.Up;
        }
    }

    private void FixedUpdate()
    {
        if (keyStateSpace == ksSpace.Down && !hasJumped)
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
        /*Vector2 direction = collision.transform.position - transform.position;

        //check whether the collision was with the ground
        if (direction.y < 0)
        {
            hasJumped = false;
            animator.SetBool("IsJumping", false);
        }*/

        if(rb.velocity.y <= 0.1f)
        {
            hasJumped = false;
            animator.SetBool("IsJumping", false);
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