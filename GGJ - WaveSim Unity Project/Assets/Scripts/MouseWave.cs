using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseWave : MonoBehaviour {

    public LayerMask enemyLayer;

    float xMovement, yMovement;

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin,ray.direction);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, enemyLayer)) {
            Enemy enemy = hit.collider.GetComponent<Enemy>();

            xMovement = Input.GetAxis("Mouse X");
            yMovement = Input.GetAxis("Mouse Y");

            enemy.satisfaction += 1 + xMovement + yMovement;
            //enemy.satisfaction++;

        }

	}
}
