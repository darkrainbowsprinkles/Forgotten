using System;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioEventListener : MonoBehaviour
{
    [SerializeField] private Door[] doors;
    [SerializeField] private AudioTrigger[] audioTriggers;

    private AudioSource audioSource;

    private void OnEnable()
    {
        foreach(Door door in doors)
        {
            door.onDoorOpened += PlayAudioClip;
        }

        foreach(AudioTrigger audioTrigger in audioTriggers)
        {
            audioTrigger.onPlayerTrigger += PlayAudioClip;
        }
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnDisable()
    {
        foreach(Door door in doors)
        {
            door.onDoorOpened -= PlayAudioClip;
        }

        
        foreach(AudioTrigger audioTrigger in audioTriggers)
        {
            audioTrigger.onPlayerTrigger += PlayAudioClip;
        }
    }

    private void PlayAudioClip(AudioClip clip)
    {
        if(clip == null) { return; }

        audioSource.PlayOneShot(clip);
    }
}
