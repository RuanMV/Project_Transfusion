using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingScript : MonoBehaviour
{
    //Variables
    //Left input down
    //Right input down

    // get the two colliders
    //[SerializeField] GameObject inputObjectLeft;
    //[SerializeField] GameObject inputObjectRight;

    [SerializeField] InputBox colliderLeft;
    [SerializeField] InputBox colliderRight;

    // Start is called before the first frame update
    void Start()
    {
       // When loaded, Have the defender facing up 
    }

    private void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {


        if (colliderLeft.pressed == true && colliderRight.pressed == false)
        {
            Rotate(5);
        }

        else if (colliderRight.pressed == true && colliderLeft.pressed == false)
        {
            Rotate(-5);
        }

        else if (colliderLeft.pressed == true && colliderRight.pressed == true)
        {
            Shoot();
        }

        //boxCollider2DLeft.InputBox.pressed = true;
        //boxCollider2DRight. = true;

        //if left and right input true

        //shoot

        //else if left true
        //rotate defender left

        //else if right true
        //rotate defender right







    }
    void Shoot()
    {
        print("shoot");
    }

    void Rotate(int Direction)
    {
        this.transform.Rotate(0, 0, Direction);
    }
}
