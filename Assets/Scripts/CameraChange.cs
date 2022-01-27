using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    //int position = 1;

    [SerializeField] GameObject productionGameObject;
    [SerializeField] private Vector3 story;
    [SerializeField] private Vector3 immunityTree;
    [SerializeField] private Vector3 settings;
    [SerializeField ]private Vector3 production;

    private bool coroutineRunning = false;

    //private



    int currentPanel = 2;

    private Vector3 touchPosition;
    private float swipeResistanceX = 100f;
    private float swipeResistanceY = 150f;

    [SerializeField] GameObject resources;

    // Start is called before the first frame update
    void Start()
    {
        //production = productionGameObject.transform.position;
    }
  


// Update is called once per frame
void Update()
    {
        SwipeCheck();
    }

    public void moveToProduction()
    {
        StartCoroutine(Scroller(1));
    }

    public void moveToStory()
    {
        StartCoroutine(Scroller(2));
    }

    public void moveToImmunityTree()
    {
        StartCoroutine(Scroller(3));
    }

    public void moveToSettings()
    {
        StartCoroutine(Scroller(4));
    }
    

    

    void SwipeCheck()
    {


        if (Input.GetMouseButtonDown(0))
        {
            touchPosition = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            Vector2 deltaSwipe = touchPosition - Input.mousePosition;

            if ((Mathf.Abs(deltaSwipe.x) > swipeResistanceX) && (Mathf.Abs(deltaSwipe.y) < swipeResistanceY))
            {
                if (deltaSwipe.x > 0)
                {

                    if(currentPanel < 4)
                    {
                        currentPanel++;
                    }

                    StartCoroutine(Scroller(currentPanel));
                }
                else
                {

                    if(currentPanel > 1)
                    {
                        currentPanel--;
                    }

                    StartCoroutine(Scroller(currentPanel));

                }
            }
        }
    }


    IEnumerator Scroller(int position)
    {
        switch (position)
        {
            case 1:
                //production screen
                //
                if (!coroutineRunning)
                {
                    coroutineRunning = true;
                    while (transform.localPosition != production)
                    {
                        //move panel
                        transform.localPosition = Vector3.MoveTowards(transform.localPosition, production, 100f);
                        //move resources
                        resources.transform.localPosition = Vector3.MoveTowards(resources.transform.localPosition, new Vector3(-1080, 815, 0), 100f);
                        yield return new WaitForSeconds(0.01f);
                    }
                    coroutineRunning = false;
                }

                break;

            case 2:
                //Story screen
                if (!coroutineRunning)
                {
                    coroutineRunning = true;
                    while (transform.localPosition != story)
                    {
                        //Move Panel
                        transform.localPosition = Vector3.MoveTowards(transform.localPosition, story, 100f);
                        //Move resources
                        resources.transform.localPosition = Vector3.MoveTowards(resources.transform.localPosition, new Vector3(0, 815, 0), 100f);
                        yield return new WaitForSeconds(0.01f);
                    }
                    coroutineRunning = false;
                }
                break;

            case 3:
                //immunity screen
                if (!coroutineRunning)
                {
                    coroutineRunning = true;

                    while (transform.localPosition != immunityTree)
                    {
                        transform.localPosition = Vector3.MoveTowards(transform.localPosition, immunityTree, 100f);

                        yield return new WaitForSeconds(0.01f);
                    }
                    coroutineRunning = false;
                }

                break;

            case 4:
                //settings screen
                if (!coroutineRunning)
                {
                    coroutineRunning = true;

                    while (transform.localPosition != settings)
                    {
                        transform.localPosition = Vector3.MoveTowards(transform.localPosition, settings, 100f);


                        yield return new WaitForSeconds(0.01f);
                    }
                    coroutineRunning = false;
                }

                break;

        }

        StopCoroutine(Scroller(position));
    }

}
