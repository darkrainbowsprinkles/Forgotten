using UnityEngine;

public class PersistentObjectSpawner : MonoBehaviour
{
    [Tooltip("This prefab will only be spawned once and will be persistent across scenes")]
    [SerializeField] GameObject persistentObjectPrefab = null;

    private static bool hasSpawned = false;

    private void Awake()
    {
        if(hasSpawned) { return; }

        SpawnPersisentObject();

        hasSpawned = true;
    }

    private void SpawnPersisentObject()
    {
        GameObject persistentObject = Instantiate(persistentObjectPrefab);

        DontDestroyOnLoad(persistentObject);
    }
}
