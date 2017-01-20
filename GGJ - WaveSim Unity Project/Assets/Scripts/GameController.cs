using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public static GameController instance;
    public static bool InputEnabled;

    public static void ChangeScene(string scene) {
        LoadingScreen.ChangeScene(scene);
    }
}
