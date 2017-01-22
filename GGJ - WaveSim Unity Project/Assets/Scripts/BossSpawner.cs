using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour {

    public static BossSpawner instance;

    public int spawnRate = 20;
    public static int counter = 0;
    public GameObject boss;
    public GameObject window;

    void Awake() {
        instance = this;
    }

    void Update() {
        if (!GameController.Paused) {
            if(counter >= spawnRate) {
                SpawnBoss(window.transform.position);
                counter = 0;
            }
        }
    }

    void SpawnBoss(Vector3 pos) {
        Vector3 spawnPos = pos;
        spawnPos.z = -1;
        GameObject obj = (GameObject)Instantiate(boss, pos, Quaternion.identity);
        obj.transform.parent = window.transform;
        obj.transform.localPosition = spawnPos;
    }
}