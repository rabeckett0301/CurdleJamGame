using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepEvents : MonoBehaviour
{
    [SerializeField] GameEvent OnSheepDied;

    private void OnDestroy()
    {
        OnSheepDied?.Raise();
    }
}
