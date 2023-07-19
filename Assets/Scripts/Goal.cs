using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    int sheepCount;

    [SerializeField] GameEvent OnSheepSaved;

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

            OnSheepSaved?.Raise();
        
            collision.gameObject.SetActive(true);
        }
    }
}
