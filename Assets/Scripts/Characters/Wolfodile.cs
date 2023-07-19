using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolfodile : MonoBehaviour
{
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //this needs to do stuff regarding the sheep count
        Debug.Log("Sheep eaten!");
        animator.SetTrigger("IsEating");
        Destroy(collision.gameObject);
    }
}
