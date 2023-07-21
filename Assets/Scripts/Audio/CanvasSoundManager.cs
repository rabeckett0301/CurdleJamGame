using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSoundManager : MonoBehaviour
{
    int numberOfStar = 0;

    [SerializeField] AudioClip[] starSounds;

    public void PlayStarSounds()
    {
        GetComponent<AudioSource>().PlayOneShot(starSounds[numberOfStar]);
        numberOfStar++;
    }
}
