using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor.SearchService;

public class TransitionChange : MonoBehaviour
{
    public Animator anim;

    public void LoadLevel(string scene)
    {
        StartCoroutine(LoadSelected(scene));
    }

    IEnumerator LoadSelected(string scene)
    {
        anim.SetTrigger("Start");

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(scene);
    }
}
