using System;
using UnityEngine;

[RequireComponent(typeof(SphereCollider), typeof(Rigidbody))]
public class Door : MonoBehaviour
{
    [SerializeField] private Key unlockKeyObject;
    [SerializeField] private string onDoorLockedDialogue = "Can't open it! Find the key";
    [SerializeField] private AudioClip onDoorOpenedClip;
    private IKey unlockKey;

    public event Action<string> onDoorLocked;
    public event Action<AudioClip> onDoorOpened;

    private void Start()
    {
        unlockKey =  unlockKeyObject.GetComponent<IKey>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<PlayerKeyInventory>(out PlayerKeyInventory inventory))
        {
            if(inventory.ContainsKey(unlockKey))
            {
                onDoorOpened?.Invoke(onDoorOpenedClip);
                Destroy(gameObject);
            }
            else
            {
                onDoorLocked?.Invoke(onDoorLockedDialogue);
            }
        }
    }
    
}
