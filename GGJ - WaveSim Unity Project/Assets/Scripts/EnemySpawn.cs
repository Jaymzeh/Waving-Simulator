using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

    public float spawnRate;
    public GameObject enemy;
    float timer = 0;



    void Update() {
        if (!GameController.Paused) {
            timer += Time.deltaTime;

            if (timer >= spawnRate) {
                SpawnEnemy();
                timer = 0;
            }
        }
    }

    void SpawnEnemy() {
        float x = Random.Range(-1.5f, 2f);
        GameObject newEnemy = (GameObject)Instantiate(enemy, new Vector3(x, 0, 1), Quaternion.identity, transform);
        newEnemy.transform.localPosition = new Vector3(x, 0, -1);
    }
}