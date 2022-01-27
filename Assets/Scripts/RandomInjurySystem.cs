using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomInjurySystem : MonoBehaviour
{
    [SerializeField] float eventTimer;
    [SerializeField] float eventOccurence { get { return EventOccurence; } set { EventOccurence = value; } }
    public float EventOccurence;

    BreachMenuScript breachMenuScript;

    [SerializeField] GameObject breachManager;

    //[SerializeField] GameObject bodyGameObject;
    //[SerializeField] GameObject chestGameObject;
    //[SerializeField] GameObject headGameObject;
    //[SerializeField] GameObject stomachGameObject;
    //[SerializeField] GameObject abdomenGameObject;
    //[SerializeField] GameObject leftShinGameObject;
    //[SerializeField] GameObject leftFootGameObject;
    //[SerializeField] GameObject rightShinGameObject;
    //[SerializeField] GameObject rightFootGameObject;
    //[SerializeField] GameObject leftShoulderGameObject;
    //[SerializeField] GameObject leftForearmGameObject;
    //[SerializeField] GameObject leftHandGameObject;
    //[SerializeField] GameObject rightShoulderGameObject;
    //[SerializeField] GameObject rightForearmGameObject;
    //[SerializeField] GameObject rightHandGameObject;

    bool injuredChest;
    bool injuredHead;
    bool injuredStomach;
    bool injuredAbdomen;
    bool injuredLeftShin;
    bool injuredLeftFoot;
    bool injuredRightShin;
    bool injuredRightFoot;
    bool injuredLeftShoulder;
    bool injuredLeftForearm;
    bool injuredLeftHand;
    bool injuredRightShoulder;
    bool injuredRightForearm;
    bool injuredRightHand;

    // Array for the random events that can occur
    public RandomInjuryEvent[] injuryEvents;

    // Array for the body parts that can be injured
    public RandomBodyPart[] bodyParts;

    private void Start()
    {
        breachMenuScript = breachManager.GetComponent<BreachMenuScript>();
    }

    // Probability-based random event selection; Selects an event based on its probability of selection
    public void SelectRandomInjuryEvent()
    {
        // Range is set explicitly to "simulate" 0% to 100% probabilities
        int i = Random.Range(0, 100);

        for(int j = 0; j < injuryEvents.Length; j++)
        {
            // Check if 'i' is within the probability range of 'injuryEvents[j]'
            if(i >= injuryEvents[j].minProbabilityRange && i <= injuryEvents[j].maxProbabilityRange)
            {
                // Execute random event
                Debug.Log(injuryEvents[j].injurySeverity);
                if (injuryEvents[j].injurySeverity == "Small Injury")
                {
                    int bloodLossRate = Random.Range(1, 5);
                    SelectRandomBodyPart(injuryEvents[j].injurySeverity, bloodLossRate);
                }
                else if (injuryEvents[j].injurySeverity == "Medium Injury")
                {
                    int bloodLossRate = Random.Range(6, 15);
                    SelectRandomBodyPart(injuryEvents[j].injurySeverity, bloodLossRate);
                }
                else if (injuryEvents[j].injurySeverity == "Severe Injury")
                {
                    int bloodLossRate = Random.Range(16, 30);
                    SelectRandomBodyPart(injuryEvents[j].injurySeverity, bloodLossRate);
                }
                break;
            }
        }
    }

    // Probability-based random body part selection; Selects a body part based on its probability of selection
    public void SelectRandomBodyPart(string injurySeverity, int bloodLossRate)
    {
        // Range is set explicitly to "simulate" 0% to 100% probabilities
        int i = Random.Range(0, 100);

        for (int j = 0; j < bodyParts.Length; j++)
        {
            // Check if 'i' is within the probability range of 'injuryEvents[j]'
            if (i >= bodyParts[j].minProbabilityRange && i <= bodyParts[j].maxProbabilityRange)
            {
                // Execute random event
                Debug.Log(bodyParts[j].bodyPart);

                EnableBodyPart(bodyParts[j].bodyPart, injurySeverity, bloodLossRate);

                break;
            }
        }
    }

    void EnableBodyPart(string bodyPart, string injurySeverity, int bloodLossRate)
    {
        if (bodyPart == "Chest" && injuredChest == false)
        {
            //chestGameObject.GetComponent<Animator>().Play("ChestFlashAnim", 0);

            breachMenuScript.EnableSlot(bodyPart, injurySeverity, bloodLossRate, Random.Range(1, 2));

            injuredChest = true;
        }

        if (bodyPart == "Head" && injuredHead == false)
        {
            //headGameObject.GetComponent<Animator>().Play("HeadFlashAnim", 0);

            breachMenuScript.EnableSlot(bodyPart, injurySeverity, bloodLossRate, Random.Range(3, 6));

            injuredHead = true;
        }

        if (bodyPart == "Stomach" && injuredStomach == false)
        {
            //stomachGameObject.GetComponent<Animator>().Play("StomachFlashAnim", 0);

            breachMenuScript.EnableSlot(bodyPart, injurySeverity, bloodLossRate, Random.Range(12, 16));

            injuredStomach = true;
        }

        if (bodyPart == "Abdomen" && injuredAbdomen == false)
        {
            //abdomenGameObject.GetComponent<Animator>().Play("AbdomenFlashAnim", 0);

            breachMenuScript.EnableSlot(bodyPart, injurySeverity, bloodLossRate, Random.Range(12, 16));

            injuredAbdomen = true;
        }

        if (bodyPart == "Left Shin" && injuredLeftShin == false)
        {
            //leftShinGameObject.GetComponent<Animator>().Play("LeftShinFlashAnim", 0);

            breachMenuScript.EnableSlot(bodyPart, injurySeverity, bloodLossRate, Random.Range(7, 9));

            injuredLeftShin = true;
        }

        if (bodyPart == "Left Foot" && injuredLeftFoot == false)
        {
            //leftFootGameObject.GetComponent<Animator>().Play("LeftFootFlashAnim", 0);

            breachMenuScript.EnableSlot(bodyPart, injurySeverity, bloodLossRate, Random.Range(7, 9));

            injuredLeftFoot = true;
        }

        if (bodyPart == "Right Shin" && injuredRightShin == false)
        {
            //rightShinGameObject.GetComponent<Animator>().Play("RightShinFlashAnim", 0);

            breachMenuScript.EnableSlot(bodyPart, injurySeverity, bloodLossRate, Random.Range(7, 9));

            injuredRightShin = true;
        }

        if (bodyPart == "Right Foot" && injuredRightFoot == false)
        {
            //rightFootGameObject.GetComponent<Animator>().Play("RightFootFlashAnim", 0);

            breachMenuScript.EnableSlot(bodyPart, injurySeverity, bloodLossRate, Random.Range(7, 9));

            injuredRightFoot = true;
        }

        if (bodyPart == "Left Shoulder" && injuredLeftShoulder == false)
        {
            //leftShoulderGameObject.GetComponent<Animator>().Play("LeftShoulderFlashAnim", 0);

            breachMenuScript.EnableSlot(bodyPart, injurySeverity, bloodLossRate, Random.Range(12, 16));

            injuredLeftShoulder = true;
        }

        if (bodyPart == "Left Forearm" && injuredLeftForearm == false)
        {
            //leftForearmGameObject.GetComponent<Animator>().Play("LeftForearmFlashAnim", 0);

            breachMenuScript.EnableSlot(bodyPart, injurySeverity, bloodLossRate, Random.Range(12, 16));

            injuredLeftForearm = true;
        }

        if (bodyPart == "Left Hand" && injuredLeftHand == false)
        {
            //leftHandGameObject.GetComponent<Animator>().Play("LeftHandFlashAnim", 0);

            breachMenuScript.EnableSlot(bodyPart, injurySeverity, bloodLossRate, Random.Range(10, 11));

            injuredLeftHand = true;
        }

        if (bodyPart == "Right Shoulder" && injuredRightHand == false)
        {
            //rightShoulderGameObject.GetComponent<Animator>().Play("RightShoulderFlashAnim", 0);

            breachMenuScript.EnableSlot(bodyPart, injurySeverity, bloodLossRate, Random.Range(12, 16));

            injuredRightHand = true;
        }

        if (bodyPart == "Right Forearm" && injuredRightForearm == false)
        {
            //rightForearmGameObject.GetComponent<Animator>().Play("RightForearmFlashAnim", 0);

            breachMenuScript.EnableSlot(bodyPart, injurySeverity, bloodLossRate, Random.Range(12, 16));

            injuredRightForearm = true;
        }

        if (bodyPart == "Right Hand" && injuredRightHand == false)
        {
            //rightHandGameObject.GetComponent<Animator>().Play("RightHandFlashAnim", 0);

            breachMenuScript.EnableSlot(bodyPart, injurySeverity, bloodLossRate, Random.Range(10, 11));

            injuredRightHand = true;
        }
    }

    public void DisableBodyPart(string bodyPart)
    {
        if (bodyPart == "Chest" && injuredChest == true)
        {
            //chestGameObject.GetComponent<Animator>().Play("Idle", 0);

            injuredChest = false;
        }

        if (bodyPart == "Head" && injuredHead == true)
        {
            //headGameObject.GetComponent<Animator>().Play("Idle", 0);

            injuredHead = false;
        }

        if (bodyPart == "Stomach" && injuredStomach == true)
        {
            //stomachGameObject.GetComponent<Animator>().Play("Idle", 0);

            injuredStomach = false;
        }

        if (bodyPart == "Abdomen" && injuredAbdomen == true)
        {
            //abdomenGameObject.GetComponent<Animator>().Play("Idle", 0);

            injuredAbdomen = false;
        }

        if (bodyPart == "Left Shin" && injuredLeftShin == true)
        {
            //leftShinGameObject.GetComponent<Animator>().Play("Idle", 0);

            injuredLeftShin = false;
        }

        if (bodyPart == "Left Foot" && injuredLeftFoot == true)
        {
            //leftFootGameObject.GetComponent<Animator>().Play("Idle", 0);

            injuredLeftFoot = false;
        }

        if (bodyPart == "Right Shin" && injuredRightShin == true)
        {
            //rightShinGameObject.GetComponent<Animator>().Play("Idle", 0);

            injuredRightShin = false;
        }

        if (bodyPart == "Right Foot" && injuredRightFoot == true)
        {
            //rightFootGameObject.GetComponent<Animator>().Play("Idle", 0);

            injuredRightFoot = false;
        }

        if (bodyPart == "Left Shoulder" && injuredLeftShoulder == true)
        {
            //leftShoulderGameObject.GetComponent<Animator>().Play("Idle", 0);

            injuredLeftShoulder = false;
        }

        if (bodyPart == "Left Foream" && injuredLeftForearm == true)
        {
            //leftForearmGameObject.GetComponent<Animator>().Play("Idle", 0);

            injuredLeftForearm = false;
        }

        if (bodyPart == "Left Hand" && injuredLeftHand == true)
        {
            //leftHandGameObject.GetComponent<Animator>().Play("Idle", 0);

            injuredLeftHand = false;
        }

        if (bodyPart == "Right Shoulder" && injuredRightShoulder == true)
        {
            //rightShoulderGameObject.GetComponent<Animator>().Play("Idle", 0);

            injuredRightShoulder = false;
        }

        if (bodyPart == "Right Forearm" && injuredRightForearm == true)
        {
            //rightForearmGameObject.GetComponent<Animator>().Play("Idle", 0);

            injuredRightForearm = false;
        }

        if (bodyPart == "Right Hand" && injuredRightHand == true)
        {
            //rightHandGameObject.GetComponent<Animator>().Play("Idle", 0);

            injuredRightHand = false;
        }
    }

    [System.Serializable]
    public class RandomInjuryEvent
    {
        public string injurySeverity = "";
        public int minProbabilityRange = 0;
        public int maxProbabilityRange = 0;
    }

    [System.Serializable]
    public class RandomBodyPart
    {
        public string bodyPart = "";
        public int minProbabilityRange = 0;
        public int maxProbabilityRange = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (breachMenuScript.SlotCount < 5)
        {
            eventTimer += Time.deltaTime;

            if (eventTimer > eventOccurence)
            {
                SelectRandomInjuryEvent();

                eventTimer = 0;
            }
        }
    }
}
