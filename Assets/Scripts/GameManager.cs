using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameEvent OnLevelStarted;

    private int sheepSpawned;
    private int sheepDied;

    public void SheepSpawn()
    {
        sheepSpawned++;
    }

    public void SheepDied()
    {
        sheepDied++;

        if (sheepDied >= 3)
        {
            Time.timeScale = 0f;
        }
    }

    private void Start()
    {
        StartLevel();
    }

    private void StartLevel()
    {
        StartCoroutine(StartLevel_Co());
    }

    private IEnumerator StartLevel_Co()
    {
        yield return new WaitForSeconds(1f);

        OnLevelStarted?.Raise();
    }
}
