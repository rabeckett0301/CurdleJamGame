using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepEvents : MonoBehaviour
{
    [SerializeField] GameEvent OnSheepDied;
    [SerializeField] GameObject deathParticleEffects;
    [SerializeField] GameObject deathGhost;

    public void DestroySheep()
    {
        Instantiate(deathParticleEffects, transform.position, Quaternion.identity);
        Instantiate(deathGhost, transform.position, Quaternion.identity);
        OnSheepDied?.Raise();
        Destroy(gameObject);
    }
}
