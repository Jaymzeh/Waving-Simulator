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
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin,ray.direction);
        RaycastHit hit;

        

        if (Physics.Raycast(ray, out hit, enemyLayer)) {

            if (transform.localEulerAngles.z > 110 || transform.eulerAngles.z < 70)
            direction *= -1;
        

            Enemy enemy = hit.collider.GetComponent<Enemy>();

            xMovement = Input.GetAxis("Mouse X");
            yMovement = Input.GetAxis("Mouse Y");

            Debug.Log("Mouse movement[" + xMovement + "," + yMovement + "]");
            Debug.Log("Total["+xMovement+yMovement+"]");
            if(xMovement+yMovement <0.25)
                transform.Rotate(0, 0, direction*slowWave);
            else
                transform.Rotate(0, 0, direction*fastWave);

            enemy.satisfaction += 1 + xMovement + yMovement;
            //enemy.satisfaction++;

        }

	}
}
