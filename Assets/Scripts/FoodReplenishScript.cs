using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FoodReplenishScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI foodAmountText;
    [SerializeField] TextMeshProUGUI waterAmountText;
    [SerializeField] TextMeshProUGUI foodRefillTimerText;

    [SerializeField] int foodIncreaseAmount { get { return FoodIncreaseAmount; } set { FoodIncreaseAmount = value; } }
    public int FoodIncreaseAmount;
    [SerializeField] int waterIncreaseAmount { get { return WaterIncreaseAmount; } set { WaterIncreaseAmount = value; } }
    public int WaterIncreaseAmount;
    [SerializeField] int foodMaxAmount = 50;
    [SerializeField] int waterMaxAmount = 50;



    [SerializeField] int foodAmount { get { return FoodAmount; } set { FoodAmount = value; } }
    public int FoodAmount;
    [SerializeField] int waterAmount { get { return WaterAmount; } set { WaterAmount = value; } }
    public int WaterAmount;
    [SerializeField] float foodRefillTimer;
    float foodRefillTimerAtStart;
    
    // Start is called before the first frame update
    void Start()
    {
        // Set the text of 'Food Text'
        foodAmountText.text = foodAmount.ToString();
        // Set the text of 'Water Text'
        waterAmountText.text = waterAmount.ToString();
        // Store a reference to the initial value of 'foodRefillTimer'
        foodRefillTimerAtStart = foodRefillTimer;
        Debug.Log("Start foodRefillTimer: " + foodRefillTimer);
        Debug.Log("Start foodRefillTimerAtStart: " + foodRefillTimerAtStart);
    }

    // Consumes one food
    public void EatFood()
    {
        if (foodAmount >= 1)
        {
            // Decrease the food amount
            foodAmount--;
            // Set the text of 'TMP-Text Food Amount'
            foodAmountText.text = foodAmount.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (foodAmount < foodMaxAmount && waterAmount < waterMaxAmount)
        {
            // Decrease the food refill timer
            foodRefillTimer -= Time.deltaTime;

            // Calculate the minutes remaining
            int minutes = Mathf.FloorToInt(foodRefillTimer / 60f);
            // Calculate the seconds remaining
            int seconds = Mathf.FloorToInt(foodRefillTimer - minutes * 60);
            // Set the format for the timer
            string stringTime = string.Format("{0:00}:{1:00}", minutes, seconds);
            // Update the text of 'TMP-TextFoodRefillTimer'
            foodRefillTimerText.text = stringTime;

            if (foodRefillTimer <= 0)
            {
                // Reset the food refill timer
                foodRefillTimer = foodRefillTimerAtStart;
                // Set the text of 'TMP-TextFoodRefillTimer'
                foodRefillTimerText.text = "00:00";
                // Increase the food amount
                foodAmount += foodIncreaseAmount;
                if (foodAmount > foodMaxAmount)
                {
                    foodAmount = foodMaxAmount;
                }
                // Set the text of 'Food Text'
                foodAmountText.text = foodAmount.ToString();
                // Increase the water amount
                waterAmount += waterIncreaseAmount;
                //Play Audio
                FindObjectOfType<AudioManager>().Play("FoodWater");
                // Set the text of 'Water Text'
                waterAmountText.text = waterAmount.ToString();
            }
        }
        else if (foodAmount < foodMaxAmount)
        {
            // Decrease the food refill timer
            foodRefillTimer -= Time.deltaTime;

            // Calculate the minutes remaining
            int minutes = Mathf.FloorToInt(foodRefillTimer / 60f);
            // Calculate the seconds remaining
            int seconds = Mathf.FloorToInt(foodRefillTimer - minutes * 60);
            // Set the format for the timer
            string stringTime = string.Format("{0:00}:{1:00}", minutes, seconds);
            // Update the text of 'TMP-TextFoodRefillTimer'
            foodRefillTimerText.text = stringTime;

            if (foodRefillTimer <= 0)
            {
                // Reset the food refill timer
                foodRefillTimer = foodRefillTimerAtStart;
                // Set the text of 'TMP-TextFoodRefillTimer'
                foodRefillTimerText.text = "00:00";
                // Increase the food amount
                foodAmount += foodIncreaseAmount;
                if (foodAmount > foodMaxAmount)
                {
                    foodAmount = foodMaxAmount;
                }
                // Set the text of 'Food Text'
                foodAmountText.text = foodAmount.ToString();
            }
        }
        else if (waterAmount < waterMaxAmount)
        {
            // Decrease the food refill timer
            foodRefillTimer -= Time.deltaTime;

            // Calculate the minutes remaining
            int minutes = Mathf.FloorToInt(foodRefillTimer / 60f);
            // Calculate the seconds remaining
            int seconds = Mathf.FloorToInt(foodRefillTimer - minutes * 60);
            // Set the format for the timer
            string stringTime = string.Format("{0:00}:{1:00}", minutes, seconds);
            // Update the text of 'TMP-TextFoodRefillTimer'
            foodRefillTimerText.text = stringTime;

            if (foodRefillTimer <= 0)
            {
                // Reset the food refill timer
                foodRefillTimer = foodRefillTimerAtStart;
                // Set the text of 'TMP-TextFoodRefillTimer'
                foodRefillTimerText.text = "00:00";
                // Increase the water amount
                waterAmount += waterIncreaseAmount;
                if (waterAmount > waterMaxAmount)
                {
                    waterAmount = waterMaxAmount;
                }
                // Set the text of 'Water Text'
                waterAmountText.text = waterAmount.ToString();
            }
        }
        // Set the text of 'FoodAmountText'
        foodAmountText.text = foodAmount.ToString();
        // Set the text of 'WaterAmountText'
        waterAmountText.text = waterAmount.ToString();
    }
}
