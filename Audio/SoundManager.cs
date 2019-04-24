using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField]
    private Sound[] SOURCES;
    private Dictionary<string, Sound> sounds = new Dictionary<string, Sound>();

    [SerializeField]
    private Sound[] SONGS;

    public int currentSong = -1;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        // PlayerPrefs.DeleteAll();

        instance = this;
        DontDestroyOnLoad(this.gameObject);

        foreach (var sound in SOURCES)
        {
            sounds[sound.ID] = sound;
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.CLIP;
            sound.source.volume = sound.VOLUME;
            sound.source.pitch = sound.PITCH;
        }

        foreach (var song in SONGS)
        {
            song.source = gameObject.AddComponent<AudioSource>();
            song.source.clip = song.CLIP;
            song.source.volume = song.VOLUME;
            song.source.pitch = song.PITCH;
        }

        currentSong = Random.Range(0, SONGS.Length);
    }

    [System.Serializable]
    public class Sound
    {
        public string ID;
        public AudioClip CLIP;
        public float VOLUME;
        public float PITCH;
        public bool MUTABLE = true;

        [HideInInspector]
        public AudioSource source;
    }

    public static void PlaySound(string s)
    {
        bool muted = PlayerPrefs.GetInt("muted") != 0;
        if (instance.sounds.ContainsKey(s) && (!muted || !instance.sounds[s].MUTABLE))
        {
            instance.sounds[s].source.Play();
        }
    }

    public static void PlaySound(string s, float pitch)
    {
        instance.sounds[s].source.pitch = pitch;
        PlaySound(s);
    }

    void Update()
    {
        if (PlayerPrefs.GetInt("muted") == 0)
        {
            if (!SONGS[currentSong].source.isPlaying)
            {
                PlayNextSong();
            }
        }
        else
        {
            SONGS[currentSong].source.Pause();
        }
    }

    public void PlayNextSong()
    {
        SONGS[currentSong].source.Pause();
        currentSong++;
        currentSong %= SONGS.Length;
        StartCoroutine(FadeIn(SONGS[currentSong].source, 1f));
    }

    public static void NextSong()
    {
        instance.PlayNextSong();
    }


    public IEnumerator FadeIn(AudioSource audioSource, float FadeTime)
    {
        float startVolume = audioSource.volume;
        audioSource.volume = 0;
        audioSource.Play();

        while (audioSource.volume < startVolume)
        {
            audioSource.volume = Mathf.MoveTowards(audioSource.volume, startVolume, Time.deltaTime / FadeTime);
            yield return null;
        }

    }
}
