using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour, IActivatable, IDestroySheep
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

    public void DestroyNPSheep(SheepEvents sheepToDestroy)
    {
        sheepToDestroy.DestroySheep();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent(out SheepEvents sheepToDestroy))
        {
            DestroyNPSheep(sheepToDestroy);
        }
    }
}
