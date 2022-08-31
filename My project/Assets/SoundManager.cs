using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public AudioClip[] clips;
    public AudioSource[] source;
    
    //For playing sounds
    
    //Need to add main menu music and level music (can be the same music)
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        
    }

    private void Start()
    {
        if (source == null)
        {
            source = new AudioSource[10];
            for (int i = 0; i < source.Length; i++)
                source[i] = new AudioSource();
        }
    }

    public void PlayClip(int index,int sourceIndex)
    {
        source[sourceIndex].Play();

    }

    public void PlayClipOneShot(int index)
    {
        source[0].PlayOneShot(clips[index]);
    }

    
}
