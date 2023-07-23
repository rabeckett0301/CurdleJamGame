using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSheep : MonoBehaviour, IPickupable
{
    public bool BeingCarried { get; set; }
    public Transform HoldPoint { get; set; }
    public bool Selected { get; set; }
    public bool CanBeCarried { get; set; }

    [SerializeField] GameObject selectedPointer;

    protected Rigidbody2D rb;
    protected Animator animator;
    protected float gravityScale;
    protected AudioSource audioSource;

    protected void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gravityScale = rb.gravityScale;
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        GameObject mySelectedPointer = Instantiate(selectedPointer, new (transform.position.x, transform.position.y + 1), Quaternion.identity);
        mySelectedPointer.transform.SetParent(transform);
        mySelectedPointer.SetActive(false);

        selectedPointer = mySelectedPointer;
        CanBeCarried = true;
    }

    public void Drop(Transform dropPoint)
    {
        BeingCarried = false;
        transform.position = dropPoint.position;
        rb.gravityScale = gravityScale;
        HoldPoint = null;
        transform.SetParent(null);
    }

    public virtual bool TryPickup(Transform holdPoint)
    {
        if (CanBeCarried)
        {
            BeingCarried = true;
            rb.gravityScale = 0;
            HoldPoint = holdPoint;
            transform.SetParent(holdPoint);
            transform.localPosition = Vector2.zero;
            return true;
        }
        else
        {
            return false;
        }
        
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
        return gameObject;
    }

    public void SetLastLookedLeft(bool lastLookedLeft)
    {
        animator.SetBool("LastLookedLeft", lastLookedLeft);
    }
}
