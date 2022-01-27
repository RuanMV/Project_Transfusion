using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI bloodAmountText;
    [SerializeField] TextMeshProUGUI whiteAmountText;
    [SerializeField] TextMeshProUGUI plasmaAmountText;
    [SerializeField] TextMeshProUGUI plateletsAmountText;

    [SerializeField] float bloodAmount { get { return BloodAmount; } set { BloodAmount = value; } }
    public float BloodAmount;
    [SerializeField] int whiteAmount { get { return WhiteAmount; } set { WhiteAmount = value; } }
    public int WhiteAmount;
    [SerializeField] int plasmaAmount { get { return PlasmaAmount; } set { PlasmaAmount = value; } }
    public int PlasmaAmount;
    [SerializeField] int plateletsAmount { get { return PlateletsAmount; } set { PlateletsAmount = value; } }
    public int PlateletsAmount;
    [SerializeField] float bloodLossAmount { get { return BloodLossAmount; } set { BloodLossAmount = value; } }
    public float BloodLossAmount;

    SceneManagerScript sceneManager;

    GameStats gameStatsScript;

    float autoSaveTimer = 60f;
        
    // Start is called before the first frame update
    void Start()
    {
        // Set the text of 'BloodCellsText'
        bloodAmountText.text = Mathf.RoundToInt(bloodAmount).ToString();
        // Set the text of 'WhiteCellsText'
        whiteAmountText.text = whiteAmount.ToString();
        // Set the text of 'PlasmaAmountText'
        plasmaAmountText.text = plasmaAmount.ToString();
        // Set the text of 'PlateletsAmountText'
        plateletsAmountText.text = plateletsAmount.ToString();

        sceneManager = GetComponent<SceneManagerScript>();

        gameStatsScript = GetComponent<GameStats>();

        gameStatsScript.LoadStats();
    }

    // Update is called once per frame
    void Update()
    {
        bloodAmount -= (bloodLossAmount/60) * Time.deltaTime;
        autoSaveTimer -= 1 * Time.deltaTime;
        
        // Update the text of 'TextBloodAmount'
        bloodAmountText.text = Mathf.RoundToInt(bloodAmount).ToString();
        // Update the text of 'WhiteCellsText'
        whiteAmountText.text = whiteAmount.ToString();
        // Update the text of 'TextPlasmaAmount'
        plasmaAmountText.text = plasmaAmount.ToString();
        // Update the text of 'PlateletsAmountText'
        plateletsAmountText.text = plateletsAmount.ToString();

        if (bloodAmount <= 0)
        {
            sceneManager.EndGame();
        }

        if (autoSaveTimer <=0)
        {
            gameStatsScript.SaveStats();

            autoSaveTimer = 60f;
        }
    }

    public void DebugMessage()
    {
        Debug.Log("Debug!");
    }
}
