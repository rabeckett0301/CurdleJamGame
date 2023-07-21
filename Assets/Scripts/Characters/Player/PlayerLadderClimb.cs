using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLadderClimb : MonoBehaviour
{
    Rigidbody2D rb;
    bool isTouchingLadder;
    bool isClimbing;
    [SerializeField] float climbSpeed;
    [SerializeField] LayerMask ladderMask;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        CheckForLadders();
        if (!isTouchingLadder) return;

        isClimbing = false;

        if (Input.GetKey(KeyCode.W))
        {
            isClimbing = true;
        }
    }

    private void FixedUpdate()
    {
        if (isTouchingLadder && isClimbing)
        {
            rb.AddForce(Vector2.up * climbSpeed, ForceMode2D.Force);
        }
    }

    void CheckForLadders()
    {
        ContactFilter2D contactFilter2D = new();
        contactFilter2D.SetLayerMask(ladderMask);
        contactFilter2D.useTriggers = true;
        Collider2D[] results = new Collider2D[1];

        Physics2D.OverlapCircle(transform.position, 0.2f, contactFilter2D, results);

        if(results[0] == null)
        {
            isTouchingLadder = false;
            return;
        }
        else
        {
            isTouchingLadder = true;
        }
    }
}
