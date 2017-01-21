using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowTransition : MonoBehaviour {

    GameObject[] windows;
    int currentWindow = 0;
    void Start() {
        windows = GameObject.FindGameObjectsWithTag("Window");
    }



    public void MoveLeft() {
        StartCoroutine("MoveWindow", Camera.main.transform.position.x - 30);
    }



    public void MoveRight() {
        StartCoroutine("MoveWindow", Camera.main.transform.position.x + 30);
    }

    IEnumerator MoveWindow(int x) {
        while (Camera.main.transform.position.x != x) {
            Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position, new Vector3(x, Camera.main.transform.position.y, Camera.main.transform.position.z), 1);
            yield return null;
        }
    }
}