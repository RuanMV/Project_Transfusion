using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sound;

    public static AudioManager instance;

    private void Awake()
    {
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
                return;
            }

            DontDestroyOnLoad(gameObject);

            foreach(Sound s in sound)
            {
                s.source = gameObject.AddComponent<AudioSource>();
                s.source.clip = s.clip;

                s.source.volume = s.volume;
                s.source.pitch = s.pitch;
                s.source.loop = s.loop;
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        //play loop1
        Play("Music1");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sound, sound => sound.name == name);

        if (s == null)
            return;
        s.source.Play();
    }

    public void Volume(string soundName, float volume)
    {
        Sound soundInstance = Array.Find(sound, sound => sound.name == soundName);

        soundInstance.source.volume = volume;

        if (soundInstance == null)
            return;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
