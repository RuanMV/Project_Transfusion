using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InjuryStats : MonoBehaviour
{
    string bodyPart { get { return BodyPart; } set { BodyPart = value; } }
    public string BodyPart;
    string severity { get { return Severity; } set { Severity = value; } }
    public string Severity;
    int bloodLossRate { get { return BloodLossRate; } set { BloodLossRate = value; } }
    public int BloodLossRate;
    int whiteCost { get { return WhiteCost; } set { WhiteCost = value; } }
    public int WhiteCost;
    int plateletsCost { get { return PlateletsCost; } set { PlateletsCost = value; } }
    public int PlateletsCost;
    int healTime { get { return HealTime; } set { HealTime = value; } }
    public int HealTime;
    int healTimeTotal { get { return HealTime; } set { HealTime = value; } }
    public int HealTimeTotal;
    string description { get { return Description; } set { Description = value; } }
    public string Description;
    bool isHealing { get { return IsHealing; } set { IsHealing = value; } }
    public bool IsHealing;

    [SerializeField] TextMeshProUGUI bodyPartText;

    // Update is called once per frame
    void Update()
    {
        bodyPartText.text = bodyPart;

        if (HealTime <= 0)
        {
            isHealing = false;
        }
    }
}
