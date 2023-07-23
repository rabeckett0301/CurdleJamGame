using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour
{
    [SerializeField] AudioMixerSnapshot defaultSnapshot;
    [SerializeField] AudioMixerSnapshot startedSnapshot;
    [SerializeField] AudioMixerSnapshot stingerSnapshot;
    [SerializeField] AudioMixerSnapshot loseSnapshot;

    [SerializeField] AudioSource calmMusicSource;
    [SerializeField] AudioSource startedMusicSource;
    [SerializeField] AudioSource stingerSource;

    [SerializeField] AudioClip winStinger;

    private void Start()
    {
        defaultSnapshot.TransitionTo(0.01f);
    }

    public void TransferToStartedSnapshot()
    {
        startedSnapshot.TransitionTo(0.25f);
    }

    public void TransferToLoseSnapshot()
    {
        startedSnapshot.TransitionTo(0.75f);
    }

    public void PlayWinStinger()
    {
        stingerSnapshot.TransitionTo(0.01f);
        stingerSource.clip = winStinger;
        stingerSource.Play();
    }
}
