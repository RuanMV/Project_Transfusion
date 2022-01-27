using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectsScript : MonoBehaviour
{

    [SerializeField] int discountMT1;
    [SerializeField] int foodAndWaterUpgrade1;
    [SerializeField] int foodAndWaterUpgrade2;
    [SerializeField] int breachTimeUpgrade1;
    [SerializeField] int breachTimeUpgrade2;
    [SerializeField] int bonusBlood1;
    //Game Manager Object
    [SerializeField] GameObject gameManager;

    FoodReplenishScript foodScript;
    RandomInjurySystem injuryScript;
    BuyMenuScript buyMenuScript;

    [SerializeField] Transform food1;
    [SerializeField] Transform food2;
    [SerializeField] Transform food3;
    [SerializeField] Transform food4;
    [SerializeField] Transform food5;
    [SerializeField] Transform drink1;
    [SerializeField] Transform drink2;
    [SerializeField] Transform drink3;
    [SerializeField] Transform drink4;
    [SerializeField] Transform drink5;




    public Sprite apple;
    public Sprite water;



    // Start is called before the first frame update
    void Start()
    {
        foodScript = gameManager.GetComponent<FoodReplenishScript>();
        injuryScript = gameManager.GetComponent<RandomInjurySystem>();
        buyMenuScript = gameManager.GetComponent<BuyMenuScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MT1Effect()
    {
        //platelets have their cost from(8 food + 2 Water) reduced to(6 food + 1 Water).
        //reference to costs
        buyMenuScript.BloodFoodCost = buyMenuScript.BloodFoodCost - discountMT1;
        buyMenuScript.BloodWaterCost = buyMenuScript.BloodWaterCost - discountMT1;

        buyMenuScript.WhiteFoodCost = buyMenuScript.WhiteFoodCost - discountMT1;
        buyMenuScript.WhiteWaterCost = buyMenuScript.WhiteWaterCost - discountMT1;

        buyMenuScript.PlasmaFoodCost = buyMenuScript.PlasmaFoodCost - discountMT1;
        buyMenuScript.PlasmaWaterCost = buyMenuScript.PlasmaWaterCost - discountMT1;

        buyMenuScript.PlateletsFoodCost = buyMenuScript.PlateletsFoodCost - discountMT1;
        buyMenuScript.PlateletsWaterCost = buyMenuScript.PlateletsWaterCost - discountMT1;

        buyMenuScript.UpdateCost();
    }


    public void FT1Effect()
    {
        //increase the amount of food and water received per cycle by +2 for both
        foodScript.FoodIncreaseAmount += foodAndWaterUpgrade1;
        foodScript.WaterIncreaseAmount += foodAndWaterUpgrade1;
       
        //change the sprite of the burger
        food1.GetComponent<Image>().sprite = apple;
        food2.GetComponent<Image>().sprite = apple;
        food3.GetComponent<Image>().sprite = apple;
        food4.GetComponent<Image>().sprite = apple;
        food5.GetComponent<Image>().sprite = apple;
    }

    public void ET1Effect()
    {
        //the amount of breaches that are received is reduced (less common) 

        injuryScript.EventOccurence += breachTimeUpgrade1;
    }

    public void MT2Effect()
    {
        //20% more red blood is created when the option is chosen 
        buyMenuScript.BloodReturnAmount = buyMenuScript.BloodReturnAmount + bonusBlood1;

        buyMenuScript.UpdateCost();
    }

    public void FT2Effect()
    {
        //increase amount of food & water received from +2 -> +5 
        foodScript.FoodIncreaseAmount += foodAndWaterUpgrade2;
        foodScript.WaterIncreaseAmount += foodAndWaterUpgrade2;

        drink1.GetComponent<Image>().sprite = water;
        drink2.GetComponent<Image>().sprite = water;
        drink3.GetComponent<Image>().sprite = water;
        drink4.GetComponent<Image>().sprite = water;
        drink5.GetComponent<Image>().sprite = water;

    }

    public void ET2Effect()
    {
        //shorted the time needed to fix(If implemented)/ OR further reduce the chance of breaches
        injuryScript.EventOccurence += breachTimeUpgrade2;


    }

    public void MT3Effect()
    {



    }

    public void FT3Effect()
    {



    }

    public void ET3Effect()
    {

    }

    public void MT4Effect()
    {

    }

    public void FT4Effect()
    {

    }

    public void ET4Effect()
    {

    }
}
