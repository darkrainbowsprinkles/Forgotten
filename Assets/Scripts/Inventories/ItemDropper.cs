using UnityEngine;

public class ItemDropper : MonoBehaviour
{
    [SerializeField] private Transform itemSpawner;
    [SerializeField] private GameObject[] items;

    public void DropRandomItem(Transform position)
    {
        GameObject item = Instantiate(GetRandomItem(), position);

        item.transform.parent = itemSpawner;
    }

    public GameObject GetRandomItem()
    {
        int randomIndex = Random.Range(0, items.Length);

        return items[randomIndex];
    }
}
