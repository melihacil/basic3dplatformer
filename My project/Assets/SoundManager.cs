using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public AudioClip[] clips;
    
    
    //For playing sounds
    
    //Need to add main menu music and level music (can be the same music)
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        
    }




    
}
