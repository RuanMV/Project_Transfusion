using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public float blood;
    public int white;
    public int plasma;
    public int platelets;
    public int food;
    public int water;
    public int immunity;

    public GameData(GameStats stats)
    {
        GameStats gameStats = stats.GetComponent<GameStats>();
        gameStats.UpdateReferences();

        blood = stats.BloodAmount;
        white = stats.WhiteAmount;
        plasma = stats.PlasmaAmount;
        platelets = stats.PlateletsAmount;
        food = stats.FoodAmount;
        water = stats.WaterAmount;
        immunity = stats.ImmunityPoints;
    }
}
