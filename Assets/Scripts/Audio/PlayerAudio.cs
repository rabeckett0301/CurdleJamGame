using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    [SerializeField] AudioClip[] footsteps;
    [SerializeField] AudioClip jumpSound;
    [SerializeField] AudioClip pickUp;
    [SerializeField] AudioClip place;

    public void PlayRandomFootstep()
    {
        GetComponent<AudioSource>().PlayOneShot(footsteps[Random.Range(0, footsteps.Length)], Random.Range(0.15f, 0.3f));
    }

    public void PlayJumpSound()
    {
        GetComponent<AudioSource>().PlayOneShot(jumpSound);
    }

    public void PlayPickupSound()
    {
        GetComponent<AudioSource>().PlayOneShot(pickUp);
    }

    public void PlayDropSound()
    {
        GetComponent<AudioSource>().PlayOneShot(place);
    }
}
