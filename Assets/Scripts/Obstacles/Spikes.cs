using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour, IActivatable
{
    [SerializeField] GameObject spikeSprites;

    public void Activate()
    {
        spikeSprites.SetActive(false);
        GetComponent<BoxCollider2D>().enabled = false;
    }

    public void Deactivate()
    {
        spikeSprites.SetActive(true);
        GetComponent<BoxCollider2D>().enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        Debug.Log("Sheep spiked!");
    }
}
