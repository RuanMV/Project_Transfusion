using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputBox : MonoBehaviour
{
    //Variables
    //serialized Switch left/right
    //serialised object Defender


    [SerializeField] bool isRight;

    public bool pressed;




    // Start is called before the first frame update
    void Start()
    {
        //if switch is left set string to left
        
    }

    // Update is called once per frame
    void Update()
    {
        //while touched
            //set the variable in Defender.RotatingScript.left

        //set back to false
    }

    private void OnMouseDown()
    {
        pressed = true;
    }

    private void OnMouseUp()
    {
        pressed = false;
    }

}
