using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] AudioClip sheepSavedClip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Sheep"))
        {
            collision.GetComponent<SheepEvents>().SaveSheep();
            GetComponent<AudioSource>().PlayOneShot(sheepSavedClip);
        }
    }
}
