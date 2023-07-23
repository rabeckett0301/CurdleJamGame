using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TransitionChange : MonoBehaviour
{
    public Animator anim;

    public void LoadLevel(string scene)
    {
        StartCoroutine(LoadSelected(scene));
    }

    public void LoadLevel(int index)
    {
        StartCoroutine(LoadSelected(index));
    }

    IEnumerator LoadSelected(string scene)
    {
        anim.SetTrigger("Start");

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(scene);
    }

    IEnumerator LoadSelected(int index)
    {
        anim.SetTrigger("Start");

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(index);
    }

    public void StopMenuMusic()
    {
        MenuMusicManager musicManager = FindObjectOfType<MenuMusicManager>();
        musicManager.DestroyMenuMusic();
    }
}
