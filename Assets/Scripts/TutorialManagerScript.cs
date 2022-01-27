using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TutorialManagerScript : MonoBehaviour
{
    [SerializeField] bool isTutorialComplete { get { return IsTutorialComplete; } set { IsTutorialComplete = value; } }
    public bool IsTutorialComplete;

    int tutCompPref = 0;
    float timer = 0;

    [SerializeField] GameObject videoPlayerObject;

    VideoPlayer videoPlayer;

    SceneManagerScript sceneManager;

    // Start is called before the first frame update
    void Start()
    {
        tutCompPref = PlayerPrefs.GetInt("TutorialSave");

        sceneManager = GetComponent<SceneManagerScript>();

        videoPlayer = videoPlayerObject.GetComponent<VideoPlayer>();

        if (tutCompPref == 1)
        {
            //EndTutorial();
        }
    }

    // Update is called once per frame
    void Update()
    {        
        if (videoPlayer.isPlaying == false && timer > 1)
        {
            EndTutorial();
            Debug.Log("End!");
        }

        timer += 1 * Time.deltaTime;
    }

    void EndTutorial()
    {
        sceneManager = GetComponent<SceneManagerScript>();

        isTutorialComplete = true;
        if (tutCompPref != 1)
        {
            PlayerPrefs.SetInt("TutorialSave", 1);
        }
        sceneManager.StartMainGame();
    }
}
