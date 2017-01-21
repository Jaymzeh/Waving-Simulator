using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseWave : MonoBehaviour {

    public LayerMask enemyLayer;
    public ParticleSystem particleSpartikle;
    public float slowWave = 0.25f;
    public float fastWave = 3;
    int direction = 1;

    float xMovement, yMovement;

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (!GameController.Paused && GameController.InputEnabled) {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin,ray.direction);
        RaycastHit hit;

        float angleRad = Mathf.Atan2(Input.mousePosition.y - transform.position.y, Input.mousePosition.x - transform.position.x);
        float angleDeg = (180 / Mathf.PI) * angleRad;
        transform.rotation = Quaternion.Euler(0, 0, angleDeg-45);

            if(particleSpartikle.isPlaying)
                particleSpartikle.Stop();
            if (Physics.Raycast(ray, out hit, enemyLayer)) {
                if(particleSpartikle.isStopped)
                particleSpartikle.Play();
                particleSpartikle.transform.position = new Vector3(hit.point.x, hit.point.y, 2);

                Enemy enemy = hit.collider.GetComponent<Enemy>();

                xMovement = Input.GetAxis("Mouse X");
                yMovement = Input.GetAxis("Mouse Y");

                enemy.satisfaction += 1 + ((xMovement * 20) + (yMovement * 20));
            }
        }
	}
}
