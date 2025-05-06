using System.Collections;
using UnityEngine;

public class LightJitter : MonoBehaviour
{
    [SerializeField] private float maxDelayTime;
    [SerializeField] private float maxIntensityValue;

    private Light myLight;
    private float randomDelay;

    void Awake()
    {
        myLight = GetComponent<Light>();
    }

    void Start()
    {
        StartCoroutine(ProcessLightJitter());
    }

    private IEnumerator ProcessLightJitter()
    {
        while(true)
        {
            randomDelay = Random.Range(0f,0.5f);

            myLight.intensity = 0;
            yield return new WaitForSeconds(randomDelay);

            randomDelay = Random.Range(0f,0.5f);

            myLight.intensity = maxIntensityValue;
            yield return new WaitForSeconds(randomDelay);
        }
    }
}
