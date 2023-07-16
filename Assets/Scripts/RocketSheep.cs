using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketSheep : MonoBehaviour, IPickupable, IInteractable
{
    public bool BeingCarried { get; set; }
    public Transform HoldPoint { get; set; }

    [SerializeField] float boostTime;
    [SerializeField] float boostForce;
    float currentTime;

    Rigidbody2D rb;
    float gravityScale;

    private void Start()
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

    private void Update()
    {
        if (HoldPoint)
        {
            transform.position = HoldPoint.position;
        }
    }

    public void Interact()
    {
        if (!BeingCarried)
        {
            StartCoroutine(UseRocket());
        }
    }

    IEnumerator UseRocket()
    {
        while(currentTime <= boostTime)
        {
            currentTime += Time.deltaTime;
            rb.velocity = new Vector2(0, boostForce);
            yield return null;
        }
    }
}
