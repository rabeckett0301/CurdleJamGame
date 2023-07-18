using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSheep : MonoBehaviour, IPickupable
{
    public bool BeingCarried { get; set; }
    public Transform HoldPoint { get; set; }
    public bool Selected { get; set; }

    [SerializeField] GameObject selectedPointer;

    protected Rigidbody2D rb;
    protected float gravityScale;

    protected void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gravityScale = rb.gravityScale;

        GameObject mySelectedPointer = Instantiate(selectedPointer, new (transform.position.x, transform.position.y + 1), Quaternion.identity);
        mySelectedPointer.transform.SetParent(transform);
        mySelectedPointer.SetActive(false);

        selectedPointer = mySelectedPointer;
    }

    public void Drop(Transform dropPoint)
    {
        BeingCarried = false;
        transform.position = dropPoint.position;
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

        if (Selected)
        {
            DisplayPickupablePointer();
        }
        else
        {
            HidePickupablePointer();
        }
    }

    public void DisplayPickupablePointer()
    {
        selectedPointer.SetActive(true);
    }

    public void HidePickupablePointer()
    {
        selectedPointer.SetActive(false);
    }

    public GameObject GetGameObject()
    {
        return this.gameObject;
    }
}
