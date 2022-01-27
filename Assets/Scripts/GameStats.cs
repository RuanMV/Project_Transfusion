using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStats : MonoBehaviour
{
    public float BloodAmount;
    public int WhiteAmount;
    public int PlasmaAmount;
    public int PlateletsAmount;
    public int FoodAmount;
    public int WaterAmount;
    public int ImmunityPoints;

    float blood { get { return BloodAmount; } set { BloodAmount = value; } }
    int white { get { return WhiteAmount; } set { WhiteAmount = value; } }
    int plasma { get { return PlasmaAmount; } set { PlasmaAmount = value; } }
    int platelets { get { return PlateletsAmount; } set { PlateletsAmount = value; } }
    int food { get { return FoodAmount; } set { FoodAmount = value; } }
    int water { get { return WaterAmount; } set { WaterAmount = value; } }
    int immunity { get { return ImmunityPoints; } set { ImmunityPoints = value; } }

    MainScript mainScript;
    FoodReplenishScript foodScript;
    ImmunityTreeScript immunityScript;

    private void Start()
    {
        mainScript = GetComponent<MainScript>();
        foodScript = GetComponent<FoodReplenishScript>();
        immunityScript = GetComponent<ImmunityTreeScript>();
        UpdateReferences();
    }

    private void Update()
    {
        blood = mainScript.BloodAmount;
        white = mainScript.WhiteAmount;
        plasma = mainScript.PlasmaAmount;
        platelets = mainScript.PlateletsAmount;
        food = foodScript.FoodAmount;
        water = foodScript.WaterAmount;
        immunity = immunityScript.GetImmunityPoints();
    }

    public void UpdateReferences()
    {
        BloodAmount = mainScript.BloodAmount;
        WhiteAmount = mainScript.WhiteAmount;
        PlasmaAmount = mainScript.PlasmaAmount;
        PlateletsAmount = mainScript.PlateletsAmount;
        FoodAmount = foodScript.FoodAmount;
        WaterAmount = foodScript.WaterAmount;
        immunity = immunityScript.GetImmunityPoints();
    }

    public void SaveStats()
    {
        SaveSystem.SaveStats(this);
    }

    public void LoadStats()
    {
        GameData data = SaveSystem.LoadStats();
        mainScript = GetComponent<MainScript>();
        foodScript = GetComponent<FoodReplenishScript>();
        immunityScript = GetComponent<ImmunityTreeScript>();

        Debug.Log(data.blood);
        Debug.Log(mainScript.BloodAmount);

        mainScript.BloodAmount = data.blood;
        mainScript.WhiteAmount = data.white;
        mainScript.PlasmaAmount = data.plasma;
        mainScript.PlateletsAmount = data.platelets;
        foodScript.FoodAmount = data.food;
        foodScript.WaterAmount = data.water;
        immunityScript.SetImmunityPoints(data.immunity);
    }
}
