using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    ksSpace keyStateSpace;

    [SerializeField] float speed;
    [SerializeField] float jumpForce;

    [HideInInspector] public LookDirection lookDirection;
    [SerializeField] LayerMask wallMask;

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

        if (IsGrounded())
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }
    }


    private void Jump()
    {
        rb.velocity = Vector2.zero;
        rb.velocity = new Vector2(0, jumpForce); 
        GetComponent<PlayerAudio>().PlayJumpSound();
    }

    public bool IsGrounded()
    {
        ContactFilter2D contactFilter2D = new();
        contactFilter2D.SetLayerMask(wallMask);
        RaycastHit2D[] result = new RaycastHit2D[1];
        Physics2D.Raycast(transform.position, Vector2.down, contactFilter2D, result, 0.75f);

        if(result[0].collider != null)
        {
            animator.SetBool("IsJumping", false);
            return true;
        }
        else
        {
            animator.SetBool("IsJumping", true);
            return false;
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