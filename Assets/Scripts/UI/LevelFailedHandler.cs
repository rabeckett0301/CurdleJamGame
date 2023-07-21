using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFailedHandler : MonoBehaviour
{
    private TransitionChange transition;

    private int deadSheepCount = 0;

    public void SheepDied()
    {
        deadSheepCount++;

        if (deadSheepCount >= GlobalConsts.MAX_SHEEP_DEATHS)
        {
            ReloadLevel();
        }
    }

    public void ReloadLevel()
    {
        transition.LoadLevel(SceneManager.GetActiveScene().name);
    }

    public void GoTo(string scene)
    {
        transition.LoadLevel(scene);
    }

    private void Awake()
    {
        try
        {
            transition = GameObject.Find("TransitionHandler").GetComponent<TransitionChange>();
        }
        catch
        {
            Debug.Log("Need to add a 'TransitionChange' prefab into the scene");
        }
    }
}
