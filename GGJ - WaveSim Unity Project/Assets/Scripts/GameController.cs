using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameController : MonoBehaviour {

    public static GameController instance;
    public static bool InputEnabled = true;
    public static bool Paused = false;
    public GameObject gameOver;
    public AudioClip newHighScoreClip;
    public static int score;
    public static int highScore;
    public static int partyCounter;
    public static int partyTarget = 50;

    void Awake() {
         if (instance == null) {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != this)
            Destroy(gameObject);
    }

    public static void ChangeScene(string scene) {
        if (scene == "Street") {
            AudioControl.instance.PlaySFX((AudioClip)Resources.Load("Audio/new_game_pressed.wav"));
            GameController.score = 0;
        }

        LoadingScreen.ChangeScene(scene);
    }

    public static void ShowGameOver() {
        Paused = true;
        GameObject go = Instantiate(instance.gameOver);
        if (score > highScore) {
            
            SaveHighScore(score);
            highScore = score;
            AudioSource source = go.GetComponent<AudioSource>();

            instance.StartCoroutine("PlayNewHighScore", source);
        }
        
    }

    IEnumerator PlayNewHighScore(AudioSource source) {
        while (source.isPlaying) {
            yield return null;
        }
        Debug.Log("Playing new high score sound");
        source.clip = newHighScoreClip;
    }

    public static int ReadHighScore() {
        string file = "High_score.txt";
        
        if (File.Exists(file)) {
            Debug.Log("File exists");
            StreamReader sr = File.OpenText(file);
            string line = sr.ReadLine();
            Debug.Log(line);
            return int.Parse(line);
        }
        return 0;
    }
    public static void SaveHighScore(int newScore) {
        string filename = "High_score.txt";
        if (File.Exists(filename)) {
            StreamWriter sr = File.CreateText(filename);
            sr.WriteLine(newScore);
            sr.Close();
            return;
        }
    }

    public static void ExitGame() {
        Application.Quit();
    }
}
