using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour, IDestroySheep
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out SheepEvents sheepEvents))
        {
            DestroyNPSheep(sheepEvents);
        }

        if(collision.TryGetComponent(out PlayerMovement player))
        {
            player.ReturnToStartPosition();
        }
    }

    public void DestroyNPSheep(SheepEvents sheepToDestroy)
    {
        sheepToDestroy.DestroySheep();
    }
}
