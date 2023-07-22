using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepPoof : MonoBehaviour
{
    [SerializeField] AudioClip[] sheepPoofs;
    
    void Start()
    {
        GetComponent<AudioSource>().PlayOneShot(sheepPoofs[Random.Range(0, sheepPoofs.Length)]);
    }
}
