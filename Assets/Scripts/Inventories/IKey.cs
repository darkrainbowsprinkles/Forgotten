using System;
using UnityEngine;

public interface IKey 
{
    event Action<string> onKeyGot;
    string OnKeyGotDialogue { get; set; }
    void OnTriggerEnter(Collider other);
}
