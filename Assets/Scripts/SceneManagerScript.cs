using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    TutorialManagerScript tutorialManager;
    MainScript mainScript;
    FoodReplenishScript foodScript;
    GameStats gameStatsScript;
    SettingsScript settingsScript;

    // Start is called before the first frame update
    void Start()
    {
        string activeScene = SceneManager.GetActiveScene().name;

        if (activeScene == "StartScene")
        {
            tutorialManager = GetComponent<TutorialManagerScript>();

            if (tutorialManager.IsTutorialComplete == false)
            {
                SceneManager.LoadScene("TutorialScene");
            }
            if (tutorialManager.IsTutorialComplete == true)
            {
                SceneManager.LoadScene("Layout Prototype");
            }
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void StartMainGame()
    {
        SceneManager.LoadScene("Layout Prototype");
    }

    public void EndGame()
    {
        mainScript = GetComponent<MainScript>();
        foodScript = GetComponent<FoodReplenishScript>();
        gameStatsScript = GetComponent<GameStats>();
        mainScript.BloodAmount = 100;
        mainScript.WhiteAmount = 30;
        mainScript.PlasmaAmount = 30;
        mainScript.PlateletsAmount = 30;
        mainScript.BloodLossAmount = 0;
        foodScript.FoodAmount = 10;
        foodScript.WaterAmount = 10;

        gameStatsScript.SaveStats();

        SceneManager.LoadScene("EndScene");
    }

    public void WatchTutorial()
    {
        PlayerPrefs.SetInt("TutorialSave", 0);

        settingsScript = GetComponent<SettingsScript>();

        if (settingsScript.GetPlayMusic() == true)
        {
            settingsScript.MusicToggle();
        }

        SceneManager.LoadScene("TutorialScene");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
