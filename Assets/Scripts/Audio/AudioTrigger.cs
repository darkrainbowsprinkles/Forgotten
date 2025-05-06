using System;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    [SerializeField] private AudioClip clip;

    public event Action<AudioClip> onPlayerTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerKeyInventory>())
        {
            onPlayerTrigger?.Invoke(clip);
            gameObject.SetActive(false);
        }
    }
}
