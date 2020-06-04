using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    Sound[] bgMusic;

    [SerializeField]
    Sound[] soundEffects;

    [SerializeField]
    AudioSource bgSource;

    [SerializeField]
    AudioSource fxSource;

    string currentSongName;
    public static AudioManager Instance;
    public static float bgVolume = 1f;
    public static float fxVolume = 1f;

    private void Awake()
    {
        if (Instance == null)//simpleton pattern
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ChangeBGVolume(float value)
    {
        bgSource.volume = value;
    }

    public void ChangeFXVolume(float value)
    {
        fxSource.volume = value;
        fxVolume = value;
    }

    public void PlayBGMusic(int levelID)
    {
        if(levelID<4)
        {
            PlayBGMusic("Forest");
        }
        else if(levelID<8)
        {
            PlayBGMusic("Village");
        }
        else if(levelID<13)
        {
            PlayBGMusic("Mountain");
        }
        else if(levelID<14)
        {
            PlayBGMusic("Dungeon");
        }
        else if(levelID < 16)
        {
            PlayBGMusic("Mountain");
        }
        else if(levelID <18)
        {
            PlayBGMusic("Dungeon");
        }
    }

    public void PlayBGMusic(string name)
    {
        Sound s = new Sound();
        foreach (Sound sound in bgMusic)
        {
            if (sound.name == name)
            {
                s = sound;
                break;
            }
        }
        if (s.name != currentSongName)
        {
            currentSongName = s.name;
            bgSource.clip = s.clip;
            bgSource.Play();
        }
    }

    public void PlaySoundEffect(string name,float delay = 0f)
    {
        Sound s = new Sound();
        foreach (Sound sound in soundEffects)
        {
            if (sound.name == name)
            {
                s = sound;
                break;
            }
        }
        fxSource.clip = s.clip;
        Invoke("FXSourcePlay", delay);
    }

    void FXSourcePlay()
    {
        fxSource.Play();
    }

    public AudioClip GetSoundEffect(string name)
    {
        Sound s = new Sound();
        foreach (Sound sound in soundEffects)
        {
            if (sound.name == name)
            {
                s = sound;
                break;
            }
        }
        if(s != null)
        {
            return s.clip;
        }
        else
        {
            return null;
        }
    }
}


