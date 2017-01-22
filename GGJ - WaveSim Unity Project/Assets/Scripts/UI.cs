using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {
    GameObject[] backgrounds;
    public static UI instance;
    
    
    void Awake() {
        instance = this;
        instance.backgrounds = GameObject.FindGameObjectsWithTag("Background");
    }

	public void ChangeScene(string scene) {
        LoadingScreen.ChangeScene(scene);
    }

    public void ExitGame() {
        GameController.ExitGame();
    }

    public void PanWindows(Vector3 direction) {
        foreach(GameObject image in instance.backgrounds) {
            image.transform.Translate(direction);
        }
    }
}