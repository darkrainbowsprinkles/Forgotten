using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    [SerializeField] private float timeToDestroy;

    void Start()
    {
        Destroy(gameObject, timeToDestroy);
    }
}
