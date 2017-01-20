using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splashscreen : MonoBehaviour {

    public float waitTime = 2;
    float timer = 0;
	void Start () {
		
	}
	
	
	void Update () {
        timer += Time.deltaTime;

        if(timer >= waitTime) {
            GameController.ChangeScene("Main Menu");
        }
	}
}
