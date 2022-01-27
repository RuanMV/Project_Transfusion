using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
    string openRedCross = "https://www.donateblood.com.au/";

    static bool playMusic = true;
    static bool playSound = true;
    static bool notificationsOn = false;

    Sound[] sound;
    AudioManager audioM;
    [SerializeField] Transform musicButton;
    [SerializeField] Transform soundButton;
    [SerializeField] Transform notificationButton;

    void OnAwake()
    {
        
    }


    // Start is called before the first frame update
    void Start()
    {
        audioM = FindObjectOfType<AudioManager>();
        soundButton.GetComponent<Image>().color = Color.grey;
        musicButton.GetComponent<Image>().color = Color.grey;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool GetPlayMusic()
    {
        return playMusic;
    }

    public void DonateNow()
    {
        Application.OpenURL(openRedCross);
    }

    public void MusicToggle()
    {
        if(playMusic == true)
        {
            //mute music
            //turn volume to zero
            //audioM.Volume("Music1", 0.0f);
            //turn color white
            musicButton.GetComponent<Image>().color = Color.white;

            audioM.GetComponent<AudioManager>().Volume("Music1", 0.0f);
            playMusic = false;
        }
        else
        {
            //switch on sound
            audioM.Volume("Music1", 0.5f);
            //turn color grey
            musicButton.GetComponent<Image>().color = Color.grey;

            playMusic = true;
        }
    }

    public void SoundToggle()
    {
        if (playSound == true)
        {
            //Switch off Sound
            AudioListener.pause = true;
            //turn color white
            soundButton.GetComponent<Image>().color = Color.white;

            playSound = false;
        }
        else
        {
            //switch on sound
            AudioListener.pause = false;
            //turn color grey
            soundButton.GetComponent<Image>().color = Color.grey;

            playSound = true;
        }
    }

    public void NotificationsToggle()
    {
        if (notificationsOn == true)
        {
            //Switch off Notifications

            //turn color white
            notificationButton.GetComponent<Image>().color = Color.white;

            notificationsOn = false;
        }
        else
        {
            //switch on Notifications

            //turn color grey
            notificationButton.GetComponent<Image>().color = Color.grey;

            notificationsOn = true;
        }
    }

    public void ActivateTutorial()
    {

    }
}
