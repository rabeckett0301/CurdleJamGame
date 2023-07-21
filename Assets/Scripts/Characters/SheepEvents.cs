using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepEvents : MonoBehaviour
{
    [Header("On Sheep Died event elements")]
    [SerializeField] GameEvent OnSheepDied;
    [SerializeField] GameObject deathParticleEffects;
    [SerializeField] GameObject deathGhost;

    [Header("On Sheep Saved event elements")]
    [SerializeField] GameEvent OnSheepSaved;

    public void DestroySheep()
    {
        Instantiate(deathParticleEffects, transform.position, Quaternion.identity);
        Instantiate(deathGhost, transform.position, Quaternion.identity);
        OnSheepDied?.Raise();
        Destroy(gameObject);
    }

    public void SaveSheep()
    {
        //do something with animation
        
        OnSheepSaved?.Raise();
        GetComponentInChildren<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
    }
}
