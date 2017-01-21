using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour {

    public float delay = 10;
    int stage = 0;
    float timer = 0;

    Text text;

	void Start () {
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer >= delay) {
            stage++;
            timer = 0;
        }

        switch (stage) {
            case 0:
                text.text = "Be polite and wave at your friendly new neighbours with the mouse.";
                break;
                case 1:
                text.text = "Be sure not to ignore any neighbours. They won't like that...";
                break;
            default:
                Destroy(gameObject);
                break;
        }
	}
}
