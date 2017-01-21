using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningBox : MonoBehaviour {

    public GameObject leftWarning, rightWarning;

	void OnTriggerEnter2D(Collider2D other) {
        if (other.GetComponentInParent<Enemy>()) {
            if (Camera.main.transform.position.x > transform.position.x) {
                leftWarning.SetActive(true);
            }
            else if (Camera.main.transform.position.x < transform.position.x) {
                rightWarning.SetActive(true);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.GetComponentInParent<Enemy>())
            if (Camera.main.transform.position.x > transform.position.x) {
                leftWarning.SetActive(false);
            }
            else if (Camera.main.transform.position.x < transform.position.x) {
                rightWarning.SetActive(false);
            }
    }
}
