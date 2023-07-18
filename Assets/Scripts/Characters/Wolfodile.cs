using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolfodile : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //this needs to do stuff regarding the sheep count
        Debug.Log("Sheep eaten!");
        Destroy(collision.gameObject);
    }
}
