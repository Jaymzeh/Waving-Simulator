using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseWave : MonoBehaviour {

    public LayerMask enemyLayer;
    public float slowWave = 0.25f;
    public float fastWave = 3;
    int direction = 1;

    float xMovement, yMovement;

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (!GameController.Paused) {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin,ray.direction);
        RaycastHit hit;

        float angleRad = Mathf.Atan2(Input.mousePosition.y - transform.position.y, Input.mousePosition.x - transform.position.x);
        float angleDeg = (180 / Mathf.PI) * angleRad;
        transform.rotation = Quaternion.Euler(0, 0, angleDeg-45);

            if (Physics.Raycast(ray, out hit, enemyLayer)) {
                Enemy enemy = hit.collider.GetComponent<Enemy>();

                xMovement = Input.GetAxis("Mouse X");
                yMovement = Input.GetAxis("Mouse Y");

                enemy.satisfaction += 1 + ((xMovement * 20) + (yMovement * 20));
            }
        }
	}
}
