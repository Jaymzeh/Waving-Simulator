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
        if (GameController.InputEnabled) {
            transform.FindChild("MoveRight").gameObject.SetActive(true);

            bool hasLeft = false;
            foreach (GameObject w in windows) {
                if (w.transform.position.x < (Camera.main.transform.position.x - 30f)) {
                    hasLeft = true;
                    break;
                }
            }
            transform.FindChild("MoveLeft").gameObject.SetActive(hasLeft);
            StartCoroutine("MoveWindow", Camera.main.transform.position.x - 30f);
        }
    }

    public void MoveRight() {
        if (GameController.InputEnabled) {
            transform.FindChild("MoveLeft").gameObject.SetActive(true);

            bool hasRight = false;
            foreach (GameObject w in windows) {
                if (w.transform.position.x > (Camera.main.transform.position.x + 30f)) {
                    hasRight = true;
                    break;
                }
            }
            transform.FindChild("MoveRight").gameObject.SetActive(hasRight);
            StartCoroutine("MoveWindow", Camera.main.transform.position.x + 30f);
        }
    }

    IEnumerator MoveWindow(int x) {
        GameController.InputEnabled = false;
        while (Camera.main.transform.position.x != x) {
            Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position, new Vector3(x, Camera.main.transform.position.y, Camera.main.transform.position.z), 1);
            yield return null;
        }
        GameController.InputEnabled = true;
    }

    

}