using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerFinalScene : MonoBehaviour
{
    [SerializeField] Key mainKeyObject;

    private IKey key;

    private void Start()
    {
        key = mainKeyObject.GetComponent<IKey>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<PlayerKeyInventory>(out PlayerKeyInventory inventory))
        {
            if(inventory.ContainsKey(key))
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                SceneManager.LoadScene(2);
            }
        }
    }
}
