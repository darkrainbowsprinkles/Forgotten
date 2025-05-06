using System;
using UnityEngine;

[Serializable]
public class Attack 
{
    [field: SerializeField] public string AnimationName { get; private set; }
    [field: SerializeField] public float Damage { get; private set; } 
}
