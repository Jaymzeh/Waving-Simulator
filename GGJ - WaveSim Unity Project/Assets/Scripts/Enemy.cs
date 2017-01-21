using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float satisfaction;
    public int targetSatisfaction = 100;
    public float speed = 1;

    void Start() {
        int headIndex = Random.Range(0, 5);

        /*GameObject head = (GameObject)Resources.Load("Heads/" + headIndex);
        head.transform.parent = transform.FindChild("HeadParent").transform;
        head.transform.localPosition = Vector3.zero;*/

        SpriteRenderer bodySprite = GetComponent<SpriteRenderer>();

        Color colour = new Color(Random.Range(0.2f, 1), Random.Range(0.2f, 1), Random.Range(0.2f, 1), 1);
        bodySprite.color = colour;
        //head.GetComponent<SpriteRenderer>().color = colour;
    }

    // Update is called once per frame
    void Update() {
        if (!GameController.Paused) {
            if (satisfaction >= targetSatisfaction) {
                transform.Translate(0, speed*1.5f, speed * 0.001f);
                transform.localScale -= (Vector3.one * 0.005f);
                if (transform.localScale.x < 0.000001f)
                    Destroy(gameObject);
            }
            else {
                transform.Translate(0, -speed, -speed * 0.001f);
                transform.localScale += (Vector3.one * 0.0005f);
            }

            if (transform.position.y <= -4.5f) {

                GameController.Paused = false;
                GameController.ShowGameOver();
            }
        }
    }
}
