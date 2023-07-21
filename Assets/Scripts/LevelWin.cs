using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelWin : MonoBehaviour
{
    public List<Image> Sprites = new List<Image>();
    public List<Sprite> WinSprites = new List<Sprite>();

    private TransitionChange transition;
    private WaitForSeconds delayPerStar= new WaitForSeconds(1f);
    private int sheepLost;

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

    public void SetScore(int amountDied)
    {
        this.sheepLost = amountDied;
    }

    private IEnumerator ShowScore()
    {
        yield return delayPerStar;

        for (int i = 0; i < sheepLost; i++)
        {
            Sprites[i].sprite = WinSprites[i];
            yield return delayPerStar;
        }


    }
}
