using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimManagerScript : MonoBehaviour
{
    Animator animBreach;
    Animator animArrow;

    [SerializeField] GameObject breachGameObject;
    [SerializeField] GameObject arrowGameObject;
    [SerializeField] GameObject tapColliderGameObject;
    [SerializeField] GameObject optionsMenuGameObject;
    [SerializeField] GameObject optionsGameObject;
    [SerializeField] GameObject infoMenuGameObject;
    [SerializeField] GameObject infoGameObject;
    [SerializeField] GameObject breachManager;
    [SerializeField] GameObject injuryAlertGameObject;
    [SerializeField] GameObject buyBloodGameObject;
    [SerializeField] GameObject buyWhiteGameObject;
    [SerializeField] GameObject buyPlasmaGameObject;
    [SerializeField] GameObject buyPlateletsGameObject;

    Collider2D arrowCollider;
    Collider2D tapCollider;

    BreachMenuScript breachMenuScript;

    bool isBreachOpen;
    bool isOptionsOpen;
    bool isInfoOpen;

    // Start is called before the first frame update
    void Start()
    {
        animBreach = breachGameObject.GetComponent<Animator>();
        animArrow = arrowGameObject.GetComponent<Animator>();

        arrowCollider = arrowGameObject.GetComponent<Collider2D>();
        tapCollider = tapColliderGameObject.GetComponent<Collider2D>();

        breachMenuScript = breachManager.GetComponent<BreachMenuScript>();

        isBreachOpen = false;
        isOptionsOpen = false;
        isInfoOpen = false;
    }

    void BreachMenuOpen()
    {
        if (isBreachOpen == false && isOptionsOpen == false && isInfoOpen == false && buyBloodGameObject.activeInHierarchy == false && buyWhiteGameObject.activeInHierarchy == false && buyPlasmaGameObject.activeInHierarchy == false && buyPlateletsGameObject.activeInHierarchy == false)
        {
            // Play the opening animation for the breach menu
            animBreach.Play("BreachMenuOpenAnim");
            animArrow.Play("ArrowBreachOpenAnim");

            isBreachOpen = true;

            // Hide the 'options' button
            optionsGameObject.SetActive(false);
            // Hide the 'info' button
            infoGameObject.SetActive(false);
            // Hide the 'tapCollider'
            tapColliderGameObject.SetActive(false);

            breachMenuScript.IsBreachScreenOpen = true;
        }
        else if (isBreachOpen == true)
        {
            // Play the closing animation for the breach menu
            animBreach.Play("BreachMenuCloseAnim");
            animArrow.Play("ArrowBreachCloseAnim");

            isBreachOpen = false;

            // Unhide the 'options' button
            optionsGameObject.SetActive(true);
            // Unhide the 'info' button
            infoGameObject.SetActive(true);
            // Unhide the 'tapCollider'
            tapColliderGameObject.SetActive(true);

            breachMenuScript.IsBreachScreenOpen = false;
        }
    }

    public void ShowOptionsMenu()
    {
        if (isOptionsOpen == false)
        {
            optionsMenuGameObject.SetActive(true);
            isOptionsOpen = true;

            arrowGameObject.SetActive(false);
            optionsGameObject.SetActive(false);
            infoGameObject.SetActive(false);
        }
        else if (isOptionsOpen == true)
        {
            optionsMenuGameObject.SetActive(false);
            isOptionsOpen = false;

            arrowGameObject.SetActive(true);
            optionsGameObject.SetActive(true);
            infoGameObject.SetActive(true);
        }
    }

    public void ShowInfoMenu()
    {
        if (isInfoOpen == false)
        {
            infoMenuGameObject.SetActive(true);
            isInfoOpen = true;

            arrowGameObject.SetActive(false);
            optionsGameObject.SetActive(false);
        }
        else if (isInfoOpen == true)
        {
            infoMenuGameObject.SetActive(false);
            isInfoOpen = false;

            arrowGameObject.SetActive(true);
            optionsGameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

            if (hit.collider != null && hit.collider == arrowCollider)
            {
                BreachMenuOpen();
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

            if (hit.collider != null && hit.collider == tapCollider)
            {
                BreachMenuOpen();
            }
        }
    }
}
