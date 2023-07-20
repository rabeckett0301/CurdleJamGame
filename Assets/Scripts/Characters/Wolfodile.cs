using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolfodile : MonoBehaviour
{
    Animator animator;

    [SerializeField] LayerMask groundLayer;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //this needs to do stuff regarding the sheep count
        if(collision.gameObject.layer == groundLayer)
        {
            return;
        }

        Debug.Log("Sheep eaten!");
        animator.SetTrigger("IsEating");
        Destroy(collision.gameObject);
    }
}
