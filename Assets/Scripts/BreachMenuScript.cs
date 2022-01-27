using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BreachMenuScript : MonoBehaviour
{
    [SerializeField] GameObject breachScreenContent;
    [SerializeField] GameObject injuryAlert;
    [SerializeField] GameObject gameManager;

    [SerializeField] GameObject injuryInfo;

    [SerializeField] GameObject activeSlot;

    [SerializeField] TextMeshProUGUI healTimeText;

    public Sprite redBar;
    public Sprite healingBar;

    bool isBreachScreenOpen { get { return IsBreachScreenOpen; } set { IsBreachScreenOpen = value; } }
    public bool IsBreachScreenOpen;

    [SerializeField] int slotCount { get { return SlotCount; } set { SlotCount = value; } }
    public int SlotCount;

    [SerializeField] int slotSpawnLoc;

    MainScript mainScript;
    RandomInjurySystem randomInjury;
    ImmunityTreeScript immunityTreeScript;

    // Start is called before the first frame update
    void Start()
    {
        mainScript = gameManager.GetComponent<MainScript>();
        randomInjury = gameManager.GetComponent<RandomInjurySystem>();
    }

    public void EnableSlot(string bodyPart, string injurySeverity, int bloodLossRate, int descriptionIndex)
    {
        //Sound effect
        FindObjectOfType<AudioManager>().Play("Injury");

        foreach (Transform slot in breachScreenContent.transform)
        {
            if (!slot.gameObject.activeSelf)
            {


                slot.gameObject.SetActive(true);
                slot.GetComponent<InjuryStats>().BodyPart = bodyPart;
                slot.GetComponent<InjuryStats>().BloodLossRate = bloodLossRate;
                mainScript.BloodLossAmount += bloodLossRate;

                slot.transform.GetChild(0).GetComponent<Image>().sprite = redBar;
                slot.transform.GetChild(0).GetComponent<Image>().fillAmount = 1f;

                AddDescription(slot, descriptionIndex);

                if (injurySeverity == "Small Injury")
                {
                    slot.GetComponent<InjuryStats>().WhiteCost = Random.Range(1, 10);
                    slot.GetComponent<InjuryStats>().PlateletsCost = Random.Range(1, 10);
                    slot.GetComponent<InjuryStats>().HealTime = Random.Range(60, 120);

                    slot.GetComponent<InjuryStats>().HealTimeTotal = slot.GetComponent<InjuryStats>().HealTime;
                }
                else if (injurySeverity == "Medium Injury")
                {
                    slot.GetComponent<InjuryStats>().WhiteCost = Random.Range(11, 20);
                    slot.GetComponent<InjuryStats>().PlateletsCost = Random.Range(11, 20);
                    slot.GetComponent<InjuryStats>().HealTime = Random.Range(120, 240);

                    slot.GetComponent<InjuryStats>().HealTimeTotal = slot.GetComponent<InjuryStats>().HealTime;
                }
                else if (injurySeverity == "Severe Injury")
                {
                    slot.GetComponent<InjuryStats>().WhiteCost = Random.Range(21, 30);
                    slot.GetComponent<InjuryStats>().PlateletsCost = Random.Range(21, 30);
                    slot.GetComponent<InjuryStats>().HealTime = Random.Range(240, 480);

                    slot.GetComponent<InjuryStats>().HealTimeTotal = slot.GetComponent<InjuryStats>().HealTime;
                }

                return;
            }


        }
    }

    void AddDescription(Transform slot, int index)
    {
        switch (index)
        {
            case 1: // Chest
                slot.GetComponent<InjuryStats>().Description = "A shark decided to have a taste test of you. Your insides are becoming outsides.";
                break;
            case 2: // Chest
                slot.GetComponent<InjuryStats>().Description = "You didn’t chew your food properly and scratched your throat.";
                break;
            case 3:
                slot.GetComponent<InjuryStats>().Description = "You listened to the newest Minecraft music video and suffered an aneurysm.";
                break;
            case 4:
                slot.GetComponent<InjuryStats>().Description = "Attempted to beat the final boss. Unfortunately, he broke your nose and you now have no job.";
                break;
            case 5:
                slot.GetComponent<InjuryStats>().Description = "You stared at the sun... MY EYES!!!";
                break;
            case 6:
                slot.GetComponent<InjuryStats>().Description = "Drank coffee before it was cool. Damn you hipsters!";
                break;
            case 7:
                slot.GetComponent<InjuryStats>().Description = "You tried to Naruto run into area 51 and got shot in the leg.";
                break;
            case 8:
                slot.GetComponent<InjuryStats>().Description = "You stepped on a Lego; your is now in a critical condition.";
                break;
            case 9:
                slot.GetComponent<InjuryStats>().Description = "You slipped on a banana peel. Really!?";
                break;
            case 10:
                slot.GetComponent<InjuryStats>().Description = "DAMN PAPER CUTS!!!";
                break;
            case 11:
                slot.GetComponent<InjuryStats>().Description = "You put your hand in a blender.  WHY!?";
                break;
            case 12:
                slot.GetComponent<InjuryStats>().Description = "You caught a bumble bee so you could pet it. You got stung...";
                break;
            case 13:
                slot.GetComponent<InjuryStats>().Description = "Internal bleeding... wait isn't that where the blood is supposed to be?!";
                break;
            case 14:
                slot.GetComponent<InjuryStats>().Description = "You were attacked by an Australian Drop Bear and suffered massive lacerations.";
                break;
            case 15:
                slot.GetComponent<InjuryStats>().Description = "You developed a severe sun burn. DAMN YOU SUN!";
                break;
            case 16:
                slot.GetComponent<InjuryStats>().Description = "You found a hole. Not in the ground, in your self.";
                break;
        }
    }

    public void InjuryPopup(GameObject slot)
    {
        FindObjectOfType<AudioManager>().Play("ButtonSound");

        activeSlot = slot;

        if (injuryInfo.activeInHierarchy == true)
        {
            activeSlot = null;
            injuryInfo.SetActive(false);
        }
        else
        {
            injuryInfo.SetActive(true);
            injuryInfo.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = slot.GetComponent<InjuryStats>().BodyPart;
            injuryInfo.transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = slot.GetComponent<InjuryStats>().WhiteCost.ToString();
            injuryInfo.transform.GetChild(3).GetChild(0).GetComponent<TextMeshProUGUI>().text = slot.GetComponent<InjuryStats>().PlateletsCost.ToString();
            injuryInfo.transform.GetChild(4).GetComponent<TextMeshProUGUI>().text = "-" + slot.GetComponent<InjuryStats>().BloodLossRate.ToString() + "/m";
            injuryInfo.transform.GetChild(5).GetComponent<TextMeshProUGUI>().text = slot.GetComponent<InjuryStats>().HealTime.ToString();
            injuryInfo.transform.GetChild(7).GetComponent<TextMeshProUGUI>().text = slot.GetComponent<InjuryStats>().Description;
        }
    }

    public void InjuryPopupClose()
    {
        FindObjectOfType<AudioManager>().Play("ButtonSound");
        activeSlot = null;
        injuryInfo.SetActive(false);

    }

    public void RepairInjury()
    {
        if (activeSlot.GetComponent<InjuryStats>().WhiteCost <= mainScript.WhiteAmount && activeSlot.GetComponent<InjuryStats>().PlateletsCost <= mainScript.PlateletsAmount)
        {
            mainScript.WhiteAmount -= activeSlot.GetComponent<InjuryStats>().WhiteCost;
            mainScript.PlateletsAmount -= activeSlot.GetComponent<InjuryStats>().PlateletsCost;
            //mainScript.BloodLossAmount -= activeSlot.GetComponent<InjuryStats>().BloodLossRate;

            randomInjury.DisableBodyPart(activeSlot.GetComponent<InjuryStats>().BodyPart);




            activeSlot.GetComponent<InjuryStats>().IsHealing = true;

            StartCoroutine(HealTime(activeSlot));

            //activeSlot.SetActive(false);
            //activeSlot = null;

            //injuryInfo.SetActive(false);
        }
        //flash the needed resources red
        else
        {
            if(!(activeSlot.GetComponent<InjuryStats>().WhiteCost <= mainScript.WhiteAmount))
            {
                StartCoroutine(TextFlash(injuryInfo.transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>()));

            }
            if (!(activeSlot.GetComponent<InjuryStats>().PlateletsCost <= mainScript.PlateletsAmount))
            {
                StartCoroutine(TextFlash(injuryInfo.transform.GetChild(3).GetChild(0).GetComponent<TextMeshProUGUI>()));

            }
            FindObjectOfType<AudioManager>().Play("Rejected");
            Debug.Log("Not enough resources!");
        }
    }

    public void SpeedUpHeal()
    {
        if (mainScript.PlasmaAmount >= 10)
        {
            mainScript.PlasmaAmount -= 10;

            activeSlot.GetComponent<InjuryStats>().HealTime -= 60;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (activeSlot != null)
        {
            int healTimer = activeSlot.GetComponent<InjuryStats>().HealTime;

            // Calculate the minutes remaining
            int minutes = Mathf.FloorToInt(healTimer / 60f);
            // Calculate the seconds remaining
            int seconds = Mathf.FloorToInt(healTimer - minutes * 60);
            // Set the format for the timer
            string stringTime = string.Format("{0:00}:{1:00}", minutes, seconds);

            healTimeText.text = stringTime;

            if (activeSlot.GetComponent<InjuryStats>().IsHealing == true)
            {
                injuryInfo.transform.GetChild(8).gameObject.SetActive(false); // Heal Button
                injuryInfo.transform.GetChild(9).gameObject.SetActive(true); // Speed Up Button
            }
            else if (activeSlot.GetComponent<InjuryStats>().IsHealing == false)
            {
                injuryInfo.transform.GetChild(8).gameObject.SetActive(true); // Heal Button
                injuryInfo.transform.GetChild(9).gameObject.SetActive(false); // Speed Up Button
            }
        }
    }

    IEnumerator HealTime(GameObject slot)
    {
        slot.transform.GetChild(0).GetComponent<Image>().sprite = healingBar;

        //end animation
        slot.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Heal");

        while (slot.GetComponent<InjuryStats>().HealTime >= 0 && slot.GetComponent<InjuryStats>().IsHealing == true)
        {
            slot.GetComponent<InjuryStats>().HealTime -= 1;

            //heal time to a percentage
            slot.transform.GetChild(0).GetComponent<Image>().fillAmount = ((float)slot.GetComponent<InjuryStats>().HealTime / (float)slot.GetComponent<InjuryStats>().HealTimeTotal);

            yield return new WaitForSeconds(1f);
        }
        //stop bleeding
        mainScript.BloodLossAmount -= slot.GetComponent<InjuryStats>().BloodLossRate;

        slot.gameObject.SetActive(false);
        activeSlot = null;
        injuryInfo.SetActive(false);


        //add immunity point and sound
        gameManager.GetComponent<ImmunityTreeScript>().AddPoint();

        StopCoroutine(HealTime(slot));
    }

    IEnumerator TextFlash(TextMeshProUGUI text)
    {
        int timesToLoop = 0;
        while(timesToLoop != 1)
        {
            text.color = Color.red;
            timesToLoop++;
            print("textred");

            yield return new WaitForSeconds(1f);
        }


        text.color = Color.white;

        StopCoroutine(TextFlash(text));

    }
}
