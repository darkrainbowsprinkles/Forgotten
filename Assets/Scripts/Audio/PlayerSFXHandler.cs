using System;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerSFXHandler : MonoBehaviour
{
    [SerializeField] private PlayerHealth health;
    [SerializeField] private AudioClip healClip;

    private AudioSource audioSource;

    private void OnEnable()
    {   
        health.onPlayerHeal += OnHeal;
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnHeal()
    {
        audioSource.PlayOneShot(healClip);
    }
}
