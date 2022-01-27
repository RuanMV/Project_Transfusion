using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseClickDebug : MonoBehaviour
{
    [SerializeField] bool debugMode;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (debugMode == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (EventSystem.current.IsPointerOverGameObject())
                    Debug.Log("Clicked: " + EventSystem.current.currentSelectedGameObject);

                else Debug.Log("Just a left-click!");
            }
        }
    }
}
