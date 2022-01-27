using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BreachSystemScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI bloodAmountText;
    [SerializeField] TextMeshProUGUI bloodFlowRateText;
    [SerializeField] TextMeshProUGUI bloodLossRateText;

    [SerializeField] float bloodAmount;
    [SerializeField] float bloodFlowRate;
    [SerializeField] float bloodLossRate;

    // Start is called before the first frame update
    void Start()
    {
        // Set the text of 'TMP-Text Blood Amount'
        bloodAmountText.text = "Blood Amount: " + bloodAmount.ToString("F0");
        // Set the text of 'TMP-Text Blood Flow Rate'
        bloodFlowRateText.text = "Blood Flow Rate: " + bloodFlowRate.ToString("F1") + "/s";
        // Set the text of 'TMP-Text Blood Loss Rate'
        bloodLossRateText.text = "Blood Loss Rate: " + bloodLossRate.ToString("F1") + "/s";
    }

    public void Bleed()
    {
        // Decrease the value of 'bloodLossRate' to increase the rate of blood loss
        bloodLossRate -= 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        // Increase the amount of blood based on the blood flow rate
        bloodAmount += bloodFlowRate * Time.deltaTime;
        // Increase the amount of blood loss based on the blood loss rate
        bloodAmount += bloodLossRate * Time.deltaTime;
        // Set the text of 'TMP-Text Blood Amount'
        bloodAmountText.text = "Blood Amount: " + bloodAmount.ToString("F0");
        // Set the text of 'TMP-Text Blood Flow Rate'
        bloodFlowRateText.text = "Blood Flow Rate: " + bloodFlowRate.ToString("F1") + "/s";
        // Set the text of 'TMP-Text Blood Loss Rate'
        bloodLossRateText.text = "Blood Loss Rate: " + bloodLossRate.ToString("F1") + "/s";
    }
}
