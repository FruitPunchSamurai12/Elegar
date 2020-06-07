using UnityEngine.Audio;
using UnityEngine;

///THIS GUY IS RESPONSIBLE FOR AUDIO
///BG MUSIC IS PLAYED ONLY FROM AUDIO MANAGER
///SOUND EFFECTS ARE PLAYED BOTH BY AUDIO MANAGER AND OTHER GAME OBJECTS

public class AudioManager : MonoBehaviour
{
    //all the background music
    [SerializeField]
    Sound[] bgMusic;

    //all the sound effects
    [SerializeField]
    Sound[] soundEffects;

    //two different audio sources for bg and fx
    [SerializeField]
    AudioSource bgSource;

    [SerializeField]
    AudioSource fxSource;

    //need that so i dont restart a song
    string currentSongName;
    public static AudioManager Instance;//simpleton
    public static float bgVolume = 1f;//volume adjustable from settings
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

    //find bg music using the level
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

    //find and play bg music using a string 
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

    //this finds and plays a sound effect using the audio manager audio source. got a delay option as well
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

    //this returns the audio clip of a sound effect for other objects to play
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


