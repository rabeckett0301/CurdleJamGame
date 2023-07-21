using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelWin : MonoBehaviour
{
    private TransitionChange transition;

    private void Awake()
    {
        transition = GameObject.Find("TransitionHandler").GetComponent<TransitionChange>();
    }
    public void NextLevel()
    {
        try
        {
            var nextLevelIndex = SceneManager.GetActiveScene().buildIndex + 1;

            transition.LoadLevel(nextLevelIndex);
        }
        catch
        {
            transition.LoadLevel("LevelSelect");
        }
    }
}
