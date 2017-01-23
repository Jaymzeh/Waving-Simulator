using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseWave : MonoBehaviour {

    public LayerMask enemyLayer;
    public float slowWave = 0.25f;
    public float fastWave = 3;
    int direction = 1;

    float xMovement, yMovement;

    void Start() {
        GameController.score = 0;
    }

    // Update is called once per frame
    void Update() {
        if (!GameController.Paused && GameController.InputEnabled) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction);

            float angleRad = Mathf.Atan2(Input.mousePosition.y - transform.position.y, Input.mousePosition.x - transform.position.x);
            float angleDeg = (180 / Mathf.PI) * angleRad;
            transform.rotation = Quaternion.Euler(0, 0, angleDeg - 45);
        }
    }
}