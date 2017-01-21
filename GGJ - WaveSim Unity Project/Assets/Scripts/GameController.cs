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
        if (score > highScore)
            highScore = score;
        Instantiate(instance.gameOver);
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

    public static void ExitGame() {
        string filename = "Highscore.txt";
        if (File.Exists(filename)) {
            Debug.Log(filename + " already exists");
            return;
        }
        StreamWriter sr = File.CreateText(filename);
        sr.WriteLine(highScore);
        sr.Close();
    }
}
