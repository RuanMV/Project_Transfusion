using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BuyMenuScript : MonoBehaviour
{
    [SerializeField] Button buyBloodButton;
    [SerializeField] Button buyWhiteButton;
    [SerializeField] Button buyPlasmaButton;
    [SerializeField] Button buyPlateletsButton;

    [SerializeField] int bloodFoodCost { get { return BloodFoodCost; } set { BloodFoodCost = value; } }
    public int BloodFoodCost;
    [SerializeField] int bloodWaterCost { get { return BloodWaterCost; } set { BloodWaterCost = value; } }
    public int BloodWaterCost;
    [SerializeField] int bloodReturnAmount { get { return BloodReturnAmount; } set { BloodReturnAmount = value; } }
    public int BloodReturnAmount;
    [SerializeField] int whiteFoodCost { get { return WhiteFoodCost; } set { WhiteFoodCost = value; } }
    public int WhiteFoodCost;
    [SerializeField] int whiteWaterCost { get { return WhiteWaterCost; } set { WhiteWaterCost = value; } }
    public int WhiteWaterCost;
    [SerializeField] int whiteReturnAmount { get { return WhiteReturnAmount; } set { WhiteReturnAmount = value; } }
    public int WhiteReturnAmount;
    [SerializeField] int plasmaFoodCost { get { return PlasmaFoodCost; } set { PlasmaFoodCost = value; } }
    public int PlasmaFoodCost;
    [SerializeField] int plasmaWaterCost { get { return PlasmaWaterCost; } set { PlasmaWaterCost = value; } }
    public int PlasmaWaterCost;
    [SerializeField] int plasmaReturnAmount { get { return PlasmaReturnAmount; } set { PlasmaReturnAmount = value; } }
    public int PlasmaReturnAmount;
    [SerializeField] int plateletsFoodCost { get { return PlateletsFoodCost; } set { PlateletsFoodCost = value; } }
    public int PlateletsFoodCost;
    [SerializeField] int plateletsWaterCost { get { return PlateletsWaterCost; } set { PlateletsWaterCost = value; } }
    public int PlateletsWaterCost;
    [SerializeField] int plateletsReturnAmount { get { return PlateletsReturnAmount; } set { PlateletsReturnAmount = value; } }
    public int PlateletsReturnAmount;


    [SerializeField] TextMeshProUGUI bloodFoodCostText;
    [SerializeField] TextMeshProUGUI bloodWaterCostText;
    [SerializeField] TextMeshProUGUI bloodReturnAmountText;
    [SerializeField] TextMeshProUGUI whiteFoodCostText;
    [SerializeField] TextMeshProUGUI whiteWaterCostText;
    [SerializeField] TextMeshProUGUI whiteReturnAmountText;
    [SerializeField] TextMeshProUGUI plasmaFoodCostText;
    [SerializeField] TextMeshProUGUI plasmaWaterCostText;
    [SerializeField] TextMeshProUGUI plasmaReturnAmountText;
    [SerializeField] TextMeshProUGUI plateletsFoodCostText;
    [SerializeField] TextMeshProUGUI plateletsWaterCostText;
    [SerializeField] TextMeshProUGUI plateletsReturnAmountText;


    MainScript mainScript;
    FoodReplenishScript foodReplenishScript;

    // Start is called before the first frame update
    void Start()
    {
        mainScript = this.GetComponent<MainScript>();
        foodReplenishScript = this.GetComponent<FoodReplenishScript>();
    }

    public void BuyBlood()
    {
        if (foodReplenishScript.FoodAmount >= bloodFoodCost && foodReplenishScript.WaterAmount >= bloodWaterCost)
        {
            foodReplenishScript.FoodAmount -= bloodFoodCost;
            foodReplenishScript.WaterAmount -= bloodWaterCost;
            mainScript.BloodAmount += bloodReturnAmount;

            buyBloodButton.GetComponent<AudioSource>().Play();
        }
    }

    public void BuyWhite()
    {
        if (foodReplenishScript.FoodAmount >= whiteFoodCost && foodReplenishScript.WaterAmount >= whiteWaterCost)
        {
            foodReplenishScript.FoodAmount -= whiteFoodCost;
            foodReplenishScript.WaterAmount -= whiteWaterCost;
            mainScript.WhiteAmount += whiteReturnAmount;

            buyBloodButton.GetComponent<AudioSource>().Play();
        }
    }

    public void BuyPlasma()
    {
        if (foodReplenishScript.FoodAmount >= plasmaFoodCost && foodReplenishScript.WaterAmount >= plasmaWaterCost)
        {
            foodReplenishScript.FoodAmount -= plasmaFoodCost;
            foodReplenishScript.WaterAmount -= plasmaWaterCost;
            mainScript.PlasmaAmount += plasmaReturnAmount;

            buyBloodButton.GetComponent<AudioSource>().Play();
        }
    }

    public void BuyPlatelets()
    {
        if (foodReplenishScript.FoodAmount >= plateletsFoodCost && foodReplenishScript.WaterAmount >= plateletsWaterCost)
        {
            foodReplenishScript.FoodAmount -= plateletsFoodCost;
            foodReplenishScript.WaterAmount -= plateletsWaterCost;
            mainScript.PlateletsAmount += plateletsReturnAmount;

            buyBloodButton.GetComponent<AudioSource>().Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // If food amount is less than 10 and/or water amount is less than 5
        if (foodReplenishScript.FoodAmount < bloodFoodCost || (foodReplenishScript.WaterAmount < bloodFoodCost && foodReplenishScript.WaterAmount < bloodWaterCost))
        {
            buyBloodButton.interactable = false;
            //buyBloodButton.
        }
        else
        {
            buyBloodButton.interactable = true;
        }

        if (foodReplenishScript.FoodAmount < whiteFoodCost || foodReplenishScript.WaterAmount < whiteWaterCost)
        {
            buyWhiteButton.interactable = false;
        }
        else
        {
            buyWhiteButton.interactable = true;
        }

        if (foodReplenishScript.FoodAmount < plasmaFoodCost || foodReplenishScript.WaterAmount < plasmaWaterCost)
        {
            buyPlasmaButton.interactable = false;
        }
        else
        {
            buyPlasmaButton.interactable = true;
        }

        if (foodReplenishScript.FoodAmount < plateletsFoodCost || foodReplenishScript.WaterAmount < plateletsWaterCost)
        {
            buyPlateletsButton.interactable = false;
        }
        else
        {
            buyPlateletsButton.interactable = true;
        }

        UpdateCost();
    }

    public void UpdateCost()
    {
        bloodFoodCostText.text = "-" + bloodFoodCost.ToString();
        bloodWaterCostText.text = "-" + bloodWaterCost.ToString();
        bloodReturnAmountText.text = "+" + bloodReturnAmount.ToString();

        whiteFoodCostText.text = "-" + whiteFoodCost.ToString();
        whiteWaterCostText.text = "-" + whiteWaterCost.ToString();

        plateletsFoodCostText.text = "-" + plateletsFoodCost.ToString();
        plateletsWaterCostText.text = "-" + plateletsWaterCost.ToString();

        plasmaFoodCostText.text = "-" + plasmaFoodCost.ToString();
        plasmaWaterCostText.text = "-" + plasmaWaterCost.ToString();
    }
}
