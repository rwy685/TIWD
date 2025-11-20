using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioClip dayBgm;
    /*public AudioClip nightBgm;
    public AudioClip gameOverBgm;
    public AudioClip titleBgm;*/

    private BGMType currentBGM;

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
        Debug.Log("PlayBGM 호출됨: " + type);

        audioSource.clip = bgms[type];
        audioSource.Play();

        Debug.Log("Clip 이름: " + audioSource.clip);
        Debug.Log("IsPlaying: " + audioSource.isPlaying);
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
        //{ BGMType.Night, nightBgm },
        //{ BGMType.GameOver, gameOverBgm },
    };

        currentBGM = BGMType.Day;
        PlayBGM(BGMType.Day);
    }

    private void Update()
    {
        if (!GameManager.Instance.isNight && currentBGM != BGMType.Day)
        {
            Debug.Log("낮브금재생");
            PlayBGM(BGMType.Day);
            currentBGM = BGMType.Day;
        }
        /*else if (GameManager.Instance.isNight && currentBGM != BGMType.Night)
        {
            Debug.Log("밤브금재생");
            PlayBGM(BGMType.Night);
            currentBGM = BGMType.Night;
        }*/
    }
}

