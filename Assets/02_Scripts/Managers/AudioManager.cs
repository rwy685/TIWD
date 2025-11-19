using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{

    AudioSource audioSource;
    public enum BGMType
    { 
        Day,
        Night,
        GameOver,
    }

    public Dictionary<BGMType, AudioClip> bgms;

    public void PlayBGM(BGMType type)
    {
        audioSource.clip = bgms[type];
        audioSource.Play();
    }
}

