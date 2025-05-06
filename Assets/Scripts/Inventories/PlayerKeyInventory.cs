using System.Collections.Generic;
using UnityEngine;

public class PlayerKeyInventory : MonoBehaviour
{
    private List<IKey> keyInventory = new List<IKey>();

    public void AddKey(IKey key)
    {
        keyInventory.Add(key);
    }

    public bool ContainsKey(IKey key)
    {
        return keyInventory.Contains(key);
    }
}
