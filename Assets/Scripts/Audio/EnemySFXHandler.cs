using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class EnemySFXHandler : MonoBehaviour
{
    [SerializeField] private AudioClip[] attackClips;
    [SerializeField] private AudioClip[] deadClips;
    [SerializeField] private AudioClip screamer;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayRandomAttackClip()
    {
        AudioClip clip = GetRandomClip(attackClips);

        audioSource.PlayOneShot(clip);
    }

    public void PlayRandomDeadClip()
    {
        AudioClip clip = GetRandomClip(deadClips);

        audioSource.PlayOneShot(clip);
    }

    public void PlayScreamer()
    {
        audioSource.PlayOneShot(screamer);
    }

    private AudioClip GetRandomClip(AudioClip[] clips)
    {
        int randomIndex = Random.Range(0, clips.Length);

        return clips[randomIndex];
    }

    public void Mute(bool state)
    {
        audioSource.mute = state;
    }
}

