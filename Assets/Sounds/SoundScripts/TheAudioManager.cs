using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TheAudioManager : Singleton<TheAudioManager>
{
    public Sound[] musicSounds, sfxSounds, sfxLoopedSounds;
    public AudioSource musicSource, sfxSource, sfxLoopedSource;

    private void Start()
    {
        PlayMusic("Night1");
    }

    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.name == name);

        if(s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }

    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            sfxSource.PlayOneShot(s.clip);
        }
    }

    public void PlayLoopedSFX(string name)
    {
        Sound s = Array.Find(sfxLoopedSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            sfxLoopedSource.clip = s.clip;
            sfxLoopedSource.Play();
        }
    }
}
