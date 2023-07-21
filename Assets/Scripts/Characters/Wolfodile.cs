using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolfodile : MonoBehaviour, IDestroySheep
{
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.TryGetComponent(out SheepEvents sheepToDestroy))
        {
            DestroyNPSheep(sheepToDestroy);
            animator.SetTrigger("IsEating");
        }
    }

    public void DestroyNPSheep(SheepEvents sheepToDestroy)
    {
        sheepToDestroy.DestroySheep();
    }
}
