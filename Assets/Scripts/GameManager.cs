using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int sheepSpawned;
    private int sheepDied;

    public void SheepSpawn()
    {
        sheepSpawned++;
    }

    public void SheepDied()
    {
        sheepDied++;
    }
}