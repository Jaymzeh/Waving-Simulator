using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControl : MonoBehaviour {

    public static AudioControl instance;
    public AudioSource musicSource;
    public AudioSource sfxSource;
    public AudioSource bossSource;

    public static AudioClip newGameClip;

    void Awake() {
        if (instance == null) {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != this)
            Destroy(gameObject);
    }
    public void PlaySFX(AudioClip clip) {
        if (!sfxSource.isPlaying) {
            sfxSource.pitch = Random.Range(0.65f, 2);
            sfxSource.clip = clip;
            sfxSource.Play();
        }
    }

    public void PlayBossSFX(AudioClip clip) {
        if (!bossSource.isPlaying) {
            bossSource.clip = clip;
            bossSource.Play();
        }
    }

    public void PlayMusic(AudioClip clip) {
        musicSource.clip = clip;
        musicSource.Play();
    }
}