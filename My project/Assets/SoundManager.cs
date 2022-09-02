using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{

    public AudioClip[] clips;
    public Sound[] sounds;
    

    public static SoundManager instance;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        

        if ( instance == null)
            instance = this;


        foreach( Sound s in sounds )
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.pitch = s.pitch;
            s.source.volume = s.volume;
            s.source.loop = s.loop;
        }
    }


    public void PlaySound(string name)
    {
        Sound s = Array.Find(sounds, x => x.name == name);
        s.source.Play();
    }


    public void ChangeVolume(float vol, string name)
    {
        Sound s  = Array.Find(sounds, x => x.name == name);
        s.source.volume = vol;
    }

    
}
