using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepEvents : MonoBehaviour
{
    [SerializeField] GameEvent OnSheepDied;
    [SerializeField] GameObject deathParticleEffects;
    [SerializeField] GameObject deathGhost;

    private void OnDestroy()
    {
        Instantiate(deathParticleEffects, transform.position, Quaternion.identity);
        Instantiate(deathGhost, transform.position, Quaternion.identity);
        OnSheepDied?.Raise();
    }
}
