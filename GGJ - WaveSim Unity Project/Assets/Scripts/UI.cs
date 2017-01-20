using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour {

	public void ChangeScene(string scene) {
        LoadingScreen.ChangeScene(scene);
    }
}