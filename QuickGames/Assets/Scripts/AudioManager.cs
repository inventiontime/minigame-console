using System;
using UnityEngine;

// NOTE:
//      PlayerPref("SFXoff") == 0 means SFX is on
//      PlayerPref("BGMoff") == 0 means BGM is on

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager instance = null;

    int prevBGMoff;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);


        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();

            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        prevBGMoff = PlayerPrefs.GetInt("BGMoff");
    }

    private void Update()
    {
        if(PlayerPrefs.GetInt("BGMoff") != prevBGMoff)
        {
            if (PlayerPrefs.GetInt("BGMoff") == 0)
            {
                Play("Background");
            }
            else
            {
                Stop("Background");
            }

            prevBGMoff = PlayerPrefs.GetInt("BGMoff");
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null)
        {
            Debug.LogError("Sound " + name + " is missing!");
            return;
        }

        if(s.isSFX)
        {
            if(PlayerPrefs.GetInt("SFXoff") == 0)
            {
                s.source.Play();
            }
        }
        else
        {
            if (PlayerPrefs.GetInt("BGMoff") == 0)
            {
                s.source.Play();
            }
        }
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogError("Sound " + name + " is missing!");
            return;
        }

        s.source.Stop();
    }
}
