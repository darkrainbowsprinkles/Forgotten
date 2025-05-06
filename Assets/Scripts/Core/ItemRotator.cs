using UnityEngine;

public class ItemRotator : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;

    private Vector3 rotation;

    private void Update()
    {
        rotation = new Vector3(0,1,0);

        transform.rotation = transform.rotation * Quaternion.Euler(rotation * rotationSpeed * Time.deltaTime);
    }

}
