using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float satisfaction;
    public int targetSatisfaction = 100;
    public float speed = 1;
    public float damage = 1;
    public float attackTimer = 1;
    float timer = 0;
    bool attacking = false;

    void Start() {
        SpriteRenderer bodySprite = GetComponent<SpriteRenderer>();

        Color colour = new Color(Random.Range(0.2f, 1), Random.Range(0.2f, 1), Random.Range(0.2f, 1), 1);
        bodySprite.color = colour;
        GetComponentInChildren<SpriteRenderer>().color = colour;
    }

    // Update is called once per frame
    void Update() {
        if (!GameController.Paused) {
            if (satisfaction >= targetSatisfaction) {
                transform.Translate(0, speed * 1.5f, speed * 0.001f);
                transform.localScale -= (Vector3.one * 0.005f);
                if (transform.localScale.x < 0.000001f) {
                    GameController.score++;
                    Destroy(gameObject);
                }
            }
            else {
                if (transform.position.y > -4.5f) {
                    transform.Translate(0, -speed, -speed * 0.001f);
                    transform.localScale += (Vector3.one * 0.0005f);
                }
            }

            if (attacking) {
                timer += Time.deltaTime;
                if (timer >= attackTimer) {
                    GetComponentInParent<EnemySpawn>().windowHealth -= damage;
                    timer = 0;
                }

            }
        }
    }

    void OnMouseEnter() {
        if (!GameController.Paused && GameController.InputEnabled) {

            float xMovement = Input.GetAxis("Mouse X");
            float yMovement = Input.GetAxis("Mouse Y");

            satisfaction += Mathf.Abs(1 + ((xMovement * 20) + (yMovement * 20)));
        }
    }

    void OnMouseStay() {
        if (!GameController.Paused && GameController.InputEnabled) {
            float xMovement = Input.GetAxis("Mouse X");
            float yMovement = Input.GetAxis("Mouse Y");

            satisfaction += Mathf.Abs(1 + ((xMovement * 20) + (yMovement * 20)));
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Touching");
        attacking = true;
    }

    void OnTriggerExit2D(Collider2D other) {
        Debug.Log("Not Touching any more");
        attacking = false;
    }
}
