using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ImmunityTreeScript : MonoBehaviour
{
    public static int immunityPoints = 0;
    AudioManager audioManager;
    EffectsScript effectScript;
    //finder
    [SerializeField] Transform contentPanel;
    [SerializeField] Transform immunityScrollButton;

    //immunity Point Displayer
    [SerializeField] Transform immunityPointCurrent;
    bool immunityTreeNotUnlocked = false;
    //Switches
    int purchaseSwitch = 1;
    int displaySwitch = 1;

    int unlockTreeCost = 3;
    //Mentality Cost
    int costMT1 = 4;
    int costMT2 = 10;
    int costMT3 = 10;
    int costMT4 = 10;
    //Food Costs
    int costFT1 = 6;
    int costFT2 = 10;
    int costFT3 = 10;
    int costFT4 = 10;
    //Exercise cost
    int costET1 = 6;
    int costET2 = 8;
    int costET3 = 14;
    int costET4 = 18;
    // standard buttons
    [SerializeField] Transform buttonUnlock;

    [SerializeField] Transform buttonMT1;
    [SerializeField] Transform buttonMT2;
    [SerializeField] Transform buttonMT3;
    [SerializeField] Transform buttonMT4;
    [SerializeField] Transform buttonFT1;
    [SerializeField] Transform buttonFT2;
    [SerializeField] Transform buttonFT3;
    [SerializeField] Transform buttonFT4;
    [SerializeField] Transform buttonET1;
    [SerializeField] Transform buttonET2;
    [SerializeField] Transform buttonET3;
    [SerializeField] Transform buttonET4;

    //shared variables
    [SerializeField] Transform descriptionText;
    [SerializeField] Transform costText;
    [SerializeField] Transform buttonConfirm;


    string descriptionUnlock = "Unlocking the Perk Tree will allow you to level up Bobert's mad stats. ";
    string descriptionMT1 = "Bob has implemented a blood accounting system. Therefore, far less cells are lost to waste.";
    string descriptionMT2 = "The store had a 50% off sale, so you could get more Hemo for your Globins.";
    string descriptionMT3 = "Text";
    string descriptionMT4 = "Text";
    string descriptionFT1 = "Bob has decided that eating burgers for every meal may not be healthy for him and tries an \na p p l e?";
    string descriptionFT2 = "Bobs brain has grown swoll from eating an apple. He begins eating foods rich in Iron and vitamin A, taking the form of red meat and vegetables such as carrots. This will increase the amount of food and water created overtime, resulting in more cell production.";
    string descriptionFT3 = "Text";
    string descriptionFT4 = "Text";
    string descriptionET1 = "Bob uses generic, no name sealant tape on injuries that case “a lot of damage”.";
    string descriptionET2 = "When injured, Bob will now take the time to rest and recover. During this time, he will Ice the wound, have plenty of rest and elevate the wound.";
    string descriptionET3 = "Text";
    string descriptionET4 = "Text";

    private void Start()
    {
        
        audioManager = FindObjectOfType<AudioManager>();
        effectScript = FindObjectOfType<EffectsScript>();
    }
    private void Update()
    {
        //update displayer
        immunityPointCurrent.GetComponent<TextMeshProUGUI>().text = immunityPoints.ToString();


        //activate immunity tree button and change its colour
        immunityScrollButton.GetComponent<Image>().color = Color.white;
        immunityScrollButton.GetComponent<Button>().interactable = true;
        //change tree to being unlocked

        
    }

    // Used for getting and saving the value of 'immunityPoints'.
    public int GetImmunityPoints()
    {
        return immunityPoints;
    }

    // Used for loading game save and setting the value of 'immuntityPoints'.
    public void SetImmunityPoints(int amount)
    {
        immunityPoints = amount;
    }

    public void PressedUnlockTechTree()
    {
        Displayer(buttonUnlock, descriptionUnlock, unlockTreeCost, 2);
    }

    public void PressedMT1()
    {
        Displayer(buttonMT1, descriptionMT1, costMT1, 3);
        ButtonReset(buttonMT1);
    }

    public void PressedMT2()
    {
        Displayer(buttonMT2, descriptionMT2, costMT2, 4);
        ButtonReset(buttonMT2);
    }

    public void PressedMT3()
    {
        Displayer(buttonMT3, descriptionMT3, costMT3, 5);
        ButtonReset(buttonMT3);
    }

    public void PressedMT4()
    {
        Displayer(buttonMT4, descriptionMT4, costMT4, 6);
        ButtonReset(buttonMT4);
    }

    public void PressedFT1()
    {
        Displayer(buttonFT1, descriptionFT1, costFT1, 7);
        ButtonReset(buttonFT1);
    }

    public void PressedFT2()
    {
        Displayer(buttonFT2, descriptionFT2, costFT2, 8);
        ButtonReset(buttonFT2);
    }

    public void PressedFT3()
    {
        Displayer(buttonFT3, descriptionFT3, costFT3, 9);
        ButtonReset(buttonFT3);
    }

    public void PressedFT4()
    {
        Displayer(buttonFT4, descriptionFT4, costFT4, 10);
        ButtonReset(buttonFT4);
    }

    public void PressedET1()
    {
        Displayer(buttonET1, descriptionET1, costET1, 11);
        ButtonReset(buttonET1);
    }

    public void PressedET2()
    {
        Displayer(buttonET2, descriptionET2, costET2, 12);
        ButtonReset(buttonET2);
    }

    public void PressedET3()
    {
        Displayer(buttonET3, descriptionET3, costET3, 13);
        ButtonReset(buttonET3);
    }

    public void PressedET4()
    {
        Displayer(buttonET4, descriptionET4, costET4, 14);
        ButtonReset(buttonET4);
    }


    void ActivatedUnlock()
    {

        //Unlock MT1
        // buttonMT1.GetComponent<Button>().interactable = true;
        buttonMT1.GetComponent<Animator>().SetTrigger("Activate");
        //Unlock FT1
        //buttonFT1.GetComponent<Button>().interactable = true;
        buttonFT1.GetComponent<Animator>().SetTrigger("Activate");

        //Unlock ET1
        //buttonET1.GetComponent<Button>().interactable = true;
        buttonET1.GetComponent<Animator>().SetTrigger("Activate");
        //Disable Unlock Button
        buttonUnlock.GetComponent<Animator>().SetTrigger("Purchased");
        //buttonUnlock.GetComponent<Button>().interactable = false;

        //play reward sound
    }
    void ActivatedMT1()
    {
        Activator(buttonMT2, buttonMT1);
        effectScript.MT1Effect();

    }

    void ActivatedMT2()
    {
        Activator(buttonMT3, buttonMT2);
        effectScript.MT2Effect();
    }

    void ActivatedMT3()
    {
        Activator(buttonMT4, buttonMT3);
        effectScript.MT3Effect();
    }

    void ActivatedMT4()
    {
        Activator(buttonMT4, buttonMT4);
        effectScript.MT4Effect();
    }

    void ActivatedFT1()
    {
        Activator(buttonFT2, buttonFT1);
        effectScript.FT1Effect();
    }

    void ActivatedFT2()
    {
        Activator(buttonFT3, buttonFT2);
        effectScript.FT2Effect();
    }

    void ActivatedFT3()
    {
        Activator(buttonFT4, buttonFT3);
        effectScript.FT3Effect();
    }

    void ActivatedFT4()
    {
        Activator(buttonFT4, buttonFT4);
        effectScript.FT4Effect();
    }

    void ActivatedET1()
    {
        Activator(buttonET2, buttonET1);
        effectScript.ET1Effect();
    }

    void ActivatedET2()
    {
        Activator(buttonET3, buttonET2);
        effectScript.ET2Effect();
    }

    void ActivatedET3()
    {
        Activator(buttonET4, buttonET3);
        effectScript.ET3Effect();
    }

    void ActivatedET4()
    {
        Activator(buttonET4, buttonET4);
        effectScript.ET4Effect();
    }

    public void ConfirmPurchase()
    {
        audioManager.Play("ButtonSound");
        switch (purchaseSwitch)
        {
            //Default
            case 1:
                //do nothing
                break;
            
            //Confirm Unlock
            case 2:
                //check points
                if(CheckAndSubtract(unlockTreeCost, buttonUnlock) == 1)
                {
                    ActivatedUnlock();
                    purchaseSwitch = 1;
                }
                else

                {
                    audioManager.Play("Rejected");
                    buttonUnlock.GetComponent<Animator>().SetTrigger("Rejected");
                    purchaseSwitch = 1;
                }
                break;

            //MT1
            case 3:
                //check points
                if (CheckAndSubtract(costMT1, buttonMT1) == 1)
                {
                    ActivatedMT1();
                    purchaseSwitch = 1;
                }
                else
                {
                    audioManager.Play("Rejected");
                    //purchaseSwitch = 1;
                }
                break;

            //MT2
            case 4:
                //do something
                //check points
                if (CheckAndSubtract(costMT2, buttonMT2) == 1)
                {
                    ActivatedMT2();
                    purchaseSwitch = 1;
                }
                else
                {
                    audioManager.Play("Rejected");
                    //purchaseSwitch = 1;
                }
                break;

            //MT3
            case 5:
                //check points
                if (CheckAndSubtract(costMT3, buttonMT3) == 1)
                {
                    ActivatedMT3();
                    purchaseSwitch = 1;
                }
                else
                {
                    audioManager.Play("Rejected");
                    //purchaseSwitch = 1;
                }
                //do something
                break;

            //MT4
            case 6:
                //check points
                if (CheckAndSubtract(costMT4, buttonMT4) == 1)
                {
                    ActivatedMT4();
                    purchaseSwitch = 1;
                }
                else
                {
                    audioManager.Play("Rejected");
                    //purchaseSwitch = 1;
                }
                //do something
                break;

            //FT1
            case 7:
                //check points
                if (CheckAndSubtract(costFT1, buttonFT1) == 1)
                {
                    ActivatedFT1();
                    purchaseSwitch = 1;
                }
                else
                {
                    audioManager.Play("Rejected");
                    //purchaseSwitch = 1;
                }
                //do something
                break;

            //FT2
            case 8:
                //check points
                if (CheckAndSubtract(costFT2, buttonFT2) == 1)
                {
                    ActivatedFT2();
                    purchaseSwitch = 1;
                }
                else
                {
                    audioManager.Play("Rejected");
                    //purchaseSwitch = 1;
                }
                //do something
                break;

            //FT3
            case 9:
                //check points
                if (CheckAndSubtract(costFT3, buttonFT3) == 1)
                {
                    ActivatedFT3();
                    purchaseSwitch = 1;
                }
                else
                {
                    audioManager.Play("Rejected");
                    //purchaseSwitch = 1;
                }
                //do something
                break;

            //FT4
            case 10:
                //check points
                if (CheckAndSubtract(costFT4, buttonFT4) == 1)
                {
                    ActivatedFT4();
                    purchaseSwitch = 1;
                }
                else
                {
                    audioManager.Play("Rejected");
                    //purchaseSwitch = 1;
                }
                //do something
                break;

            //ET1
            case 11:
                //check points
                if (CheckAndSubtract(costET1, buttonET1) == 1)
                {
                    ActivatedET1();
                    purchaseSwitch = 1;
                }
                else
                {
                    audioManager.Play("Rejected");
                    //purchaseSwitch = 1;
                }
                //do something
                break;

            //ET2
            case 12:
                //check points
                if (CheckAndSubtract(costET2, buttonET2) == 1)
                {
                    ActivatedET2();
                    purchaseSwitch = 1;
                }
                else
                {
                    audioManager.Play("Rejected");
                    //purchaseSwitch = 1;
                }
                //do something
                break;

            //ET3
            case 13:
                //check points
                if (CheckAndSubtract(costET3, buttonET3) == 1)
                {
                    ActivatedET3();
                    purchaseSwitch = 1;
                }
                else
                {
                    audioManager.Play("Rejected");
                    //purchaseSwitch = 1;
                }
                //do something
                break;

            //ET4
            case 14:
                //check points
                if (CheckAndSubtract(costET4, buttonET4) == 1)
                {
                    ActivatedET4();
                    purchaseSwitch = 1;
                }
                else
                {
                    audioManager.Play("Rejected");
                    //purchaseSwitch = 1;
                }
                break;

        }
    }

    void Displayer(Transform buttonClicked, string description, int unlockCost, int switchNo)
    {
        //Description Text
        descriptionText.GetComponent<TextMeshProUGUI>().text = description;
        //Tech Cost
        costText.GetComponent<TextMeshProUGUI>().text = "-" + unlockCost.ToString();
        //Change image Color to show its active
        buttonClicked.GetComponent<Animator>().SetTrigger("Select");
        //buttonClicked.GetComponent<Image>().color = Color.gray;

        audioManager.Play("ButtonSound");
        purchaseSwitch = switchNo;
    }

    static int CheckAndSubtract(int perkCost, Transform currentButton)
    {
        if(immunityPoints < perkCost)
        {
           // print("Insufficient funds");
            currentButton.GetComponent<Animator>().SetTrigger("Reject");
            

            return 0;
        }

        else if (immunityPoints >= perkCost)
        {
            immunityPoints = immunityPoints - perkCost;

            return 1;
        }
        return 0;
    }

    void Activator(Transform nextButton, Transform currentButton)
    {
        //Unlock next tier
        nextButton.GetComponent<Button>().interactable = true;
        nextButton.GetComponent<Animator>().SetTrigger("Activate");
        
        //Disable this button
        currentButton.GetComponent<Animator>().SetTrigger("Purchased");
        print("Purchased");

        //play reward sound
    }

    void ButtonReset(Transform activatedButton)
    {
        //reset visuals of all buttons
        //buttonMT1.GetComponent<Animator>().SetTrigger("Activate");

        buttonMT1.GetComponent<Animator>().SetBool("Selected", false);
        buttonMT2.GetComponent<Animator>().SetBool("Selected", false);
        buttonMT2.GetComponent<Animator>().SetBool("Selected", false);
        buttonMT3.GetComponent<Animator>().SetBool("Selected", false);
        buttonMT4.GetComponent<Animator>().SetBool("Selected", false);
        buttonET1.GetComponent<Animator>().SetBool("Selected", false);
        buttonET2.GetComponent<Animator>().SetBool("Selected", false);
        buttonET3.GetComponent<Animator>().SetBool("Selected", false);
        buttonET4.GetComponent<Animator>().SetBool("Selected", false);
        buttonFT1.GetComponent<Animator>().SetBool("Selected", false);
        buttonFT2.GetComponent<Animator>().SetBool("Selected", false);
        buttonFT3.GetComponent<Animator>().SetBool("Selected", false);
        buttonFT4.GetComponent<Animator>().SetBool("Selected", false);
        //buttonUnlock.GetComponent<Image>().color = Color.white;

        //Set Visibility to special on current button
        //activatedButton.GetComponent<Image>().color = Color.grey;
        activatedButton.GetComponent<Animator>().SetBool("Selected", true);
    }

    public void AddPoint()
    {
        immunityPoints++;
        audioManager.Play("Heal");
    }
}


