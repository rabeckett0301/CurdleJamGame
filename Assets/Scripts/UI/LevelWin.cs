using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelWin : MonoBehaviour
{
    [SerializeField] GameEvent OnStarSpawn;

    public List<Image> Sprites = new List<Image>();
    public List<Sprite> WinSprites = new List<Sprite>();

    private TransitionChange transition;
    private WaitForSeconds initialDelay = new WaitForSeconds(2.25f);
    private WaitForSeconds delayPerStar= new WaitForSeconds(0.5f);
    private int sheepLost;

    private void Awake()
    {
        transition = GameObject.Find("TransitionHandler").GetComponent<TransitionChange>();
    }
    public void NextLevel()
    {
        var nextLevelIndex = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextLevelIndex < GlobalConsts.SCENE_COUNT)
        {
            transition.LoadLevel(nextLevelIndex);
        }
        else
        {
            transition.LoadLevel("LevelSelect");
        }
    }

    public void SheepLost()
    {
        sheepLost++;
    }

    public void RevealScoreInUI()
    {
        StartCoroutine(ShowScore());
    }

    private IEnumerator ShowScore()
    {
        yield return initialDelay;

        for (int i = 0; i < GlobalConsts.MAX_SHEEP_DEATHS - sheepLost; i++)
        {
            Sprites[i].sprite = WinSprites[i];
            OnStarSpawn?.Raise();
            yield return delayPerStar;
        }


    }
}
