using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISwitcher : MonoBehaviour
{   
    [SerializeField] GameObject entryPoint;

    private void Start()
    {
        SwitchTo(entryPoint);
    }

    public void SwitchTo(GameObject UIToDisplay)
    {
        if(UIToDisplay.transform.parent != transform) 
        {
            return;
        }

        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(child.gameObject == UIToDisplay);
        }
    }
}
