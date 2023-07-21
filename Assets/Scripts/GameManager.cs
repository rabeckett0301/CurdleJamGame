using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameEvent OnLevelStarted;
    public GameEvent OnWin;

    private int sheepSpawned;
    private int sheepDied;
    private int sheepSaved;

    public void SheepSpawn()
    {
        sheepSpawned++;
    }

    public void LoadNewLevel()
    {
        if (sheepSpawned == sheepSaved + sheepDied && sheepDied < GlobalConsts.MAX_SHEEP_DEATHS)
        {
            OnWin?.Raise();
        }
    }

    public void IncreaseSheepCount()
    {
        sheepSpawned++;
    }

    public void IncreaseDeadSheep()
    {
        sheepDied++;
    }
    public void IncreaseSavedSheep()
    {
        sheepSaved++;
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
