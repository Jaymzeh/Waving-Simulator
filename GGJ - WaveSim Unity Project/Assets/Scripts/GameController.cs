using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public static GameController instance;
    public static bool InputEnabled;
    public static bool Paused = false;
    public GameObject gameOver;

    void Awake() {
        instance = this;
    }

    public static void ChangeScene(string scene) {
        LoadingScreen.ChangeScene(scene);
    }

    public static void ShowGameOver() {
        Paused = true;
        Instantiate(instance.gameOver);
    }
}
