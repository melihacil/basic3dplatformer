using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Sound : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;

    public string soundName;
    public bool loop;

    [Range(0f, 1f)]
    public float volume;
    [Range (.1f, 5f)]
    public float pitch;


}
