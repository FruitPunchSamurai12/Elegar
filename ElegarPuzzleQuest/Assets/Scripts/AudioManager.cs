using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    Sound[] BGMusic;

    [SerializeField]
    AudioSource source;

    string currentSongName;
    public static AudioManager Instance;

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
        foreach (Sound sound in BGMusic)
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
            source.clip = s.clip;
            source.Play();
        }
    }

}
