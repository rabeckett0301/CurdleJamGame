using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LevelLock : MonoBehaviour
{
    public List<Button> levels = new List<Button>();

    private int unlocked;

    private void Awake()
    {
        if (!PlayerPrefs.HasKey(GlobalConsts.LEVELS_UNLOCKED)) { PlayerPrefs.SetInt(GlobalConsts.LEVELS_UNLOCKED, 1); }
    }

    private void OnEnable()
    {
        LockLevels();

        print($"index: {PlayerPrefs.GetInt(GlobalConsts.LEVELS_UNLOCKED)}");
    }

    public void LockLevels()
    {
        unlocked = PlayerPrefs.GetInt(GlobalConsts.LEVELS_UNLOCKED);
        try
        {
            for (var i = 0; i < unlocked; i++)
            {
                levels[i].interactable = true;
            }
        }
        catch { }
    }


}
