using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSheep : MonoBehaviour, IPickupable
{
    public bool BeingCarried { get; set; }
    public Transform HoldPoint { get; set; }

    protected Rigidbody2D rb;
    protected float gravityScale;

    protected void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gravityScale = rb.gravityScale;
    }

    public void Drop()
    {
        BeingCarried = false;
        rb.gravityScale = gravityScale;
        HoldPoint = null;
    }

    public void Pickup(Transform holdPoint)
    {
        BeingCarried = true;
        rb.gravityScale = 0;
        HoldPoint = holdPoint;
    }

    protected void Update()
    {
        if (HoldPoint)
        {
            transform.position = HoldPoint.position;
        }
    }
}
