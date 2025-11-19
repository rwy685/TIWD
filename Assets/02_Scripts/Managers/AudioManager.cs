using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{

    public AudioClip dayBgm;
    public AudioClip nightBgm;
    public AudioClip gameOverBgm;
    public AudioClip titleBgm;

    AudioSource audioSource;

    public enum BGMType
    { 
        Day,
        Night,
        GameOver,
        Title
    }

    public enum SFXType
    { 
        Attack,
        Walk,
        Monster
    }

    public Dictionary<BGMType, AudioClip> bgms;

    public void PlayBGM(BGMType type)
    {
        audioSource.clip = bgms[type];
        audioSource.Play();
    }

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        bgms = new Dictionary<BGMType, AudioClip>()
    {
        { BGMType.Day, dayBgm },
        { BGMType.Night, nightBgm },
        { BGMType.GameOver, gameOverBgm },
    };
    }
}

