using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LevelLock : MonoBehaviour
{
    public List<Button> levels = new List<Button>();

    private int unlocked;

    public void LockLevels()
    {
        unlocked = PlayerPrefs.GetInt(GlobalConsts.LEVELS_UNLOCKED);

        for (var i = 0; i <= unlocked; i++)
        {
            levels[i + 1].interactable = true;
        }
    }


}
