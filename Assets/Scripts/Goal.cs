using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] SheepSpawner sheepSpawner;
    int sheepCount;

    private void Start()
    {
        sheepCount = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Sheep"))
        {
            sheepCount++;
            Debug.Log("Saved " + sheepCount + " sheep!");
            Destroy(collision.gameObject);
        }
    }
}
