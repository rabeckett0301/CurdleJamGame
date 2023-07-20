using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZoneSideView : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("You lose! Good day sir!");

        if(collision.TryGetComponent(out PlayerMovement player))
        {
            player.ReturnToStartPosition();
        }
    }
}
