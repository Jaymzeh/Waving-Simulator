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

    void Awake() {
        instance = this;
    }

    public static void ChangeScene(string scene) {
        LoadingScreen.ChangeScene(scene);
    }

    public static void ShowGameOver() {
        Paused = true;
        GameObject go = Instantiate(instance.gameOver);
        if (score > highScore) {
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
        string file = "Highscore.txt";
        int score = 0;
        if (File.Exists(file)) {
            StreamReader sr = File.OpenText(file);
            string line = sr.ReadLine();
            Int32.TryParse(line, out score);
        }
        return score;
    }
    public static void SaveHighScore(int newScore) {
        string filename = "Highscore.txt";
        if (File.Exists(filename)) {
            Debug.Log(filename + " already exists");
            return;
        }
        StreamWriter sr = File.CreateText(filename);
        sr.WriteLine(newScore);
        sr.Close();
    }

    public static void ExitGame() {
        if (score > highScore)
            SaveHighScore(score);
        Application.Quit();
    }
}
