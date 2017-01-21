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
        transform.FindChild("MoveRight").gameObject.SetActive(true);

        bool hasLeft = false;
        foreach (GameObject w in windows) {
            if (w.transform.position.x < (Camera.main.transform.position.x - 30)) {
                hasLeft = true;
                break;
            }
        }
        transform.FindChild("MoveLeft").gameObject.SetActive(hasLeft);
        StartCoroutine("MoveWindow", Camera.main.transform.position.x - 30);
    }

    public void MoveRight() {
        transform.FindChild("MoveLeft").gameObject.SetActive(true);

        bool hasRight = false;
        foreach (GameObject w in windows) {
            if (w.transform.position.x > (Camera.main.transform.position.x + 30)) {
                hasRight = true;
                break;
            }
        }
        transform.FindChild("MoveRight").gameObject.SetActive(hasRight);
        StartCoroutine("MoveWindow", Camera.main.transform.position.x + 30);
    }

    IEnumerator MoveWindow(int x) {
        while (Camera.main.transform.position.x != x) {
            Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position, new Vector3(x, Camera.main.transform.position.y, Camera.main.transform.position.z), 1);
            yield return null;
        }
    }

    

}