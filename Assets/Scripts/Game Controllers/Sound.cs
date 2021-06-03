using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public AudioClip clip;
    public string soundName;
    public bool loop;
    [Range(0, 1)] public float volume = .5f;
    [HideInInspector] public AudioSource source;
}
