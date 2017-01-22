using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControl : MonoBehaviour {

    public static AudioControl instance;
    public static AudioSource musicSource;
    public static AudioSource sfxSourceOne, sfxSourceTwo;

    public static AudioClip newGameClip;

    void Awake() {

        if (instance == null) {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != this)
            Destroy(gameObject);
    }
}