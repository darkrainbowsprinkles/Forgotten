using System;
using UnityEngine;

[RequireComponent(typeof(SphereCollider), typeof(Rigidbody))]
public class Key : MonoBehaviour, IKey
{
    [field: SerializeField] public string OnKeyGotDialogue { get; set; } = "Got Main Entrance Key";

    public event Action<string> onKeyGot;

    public void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<PlayerKeyInventory>(out PlayerKeyInventory inventory))
        {
            onKeyGot?.Invoke(OnKeyGotDialogue);

            inventory.AddKey(this);
            gameObject.SetActive(false);
        }
    }
}
