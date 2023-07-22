using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    [SerializeField] AudioClip[] footsteps;

    public void PlayRandomFootstep()
    {
        GetComponent<AudioSource>().PlayOneShot(footsteps[Random.Range(0, footsteps.Length)], Random.Range(0.15f, 0.3f));
    }
}
