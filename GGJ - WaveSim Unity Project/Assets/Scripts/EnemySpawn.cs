using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawn : MonoBehaviour {

    public float spawnRate;
    public GameObject[] enemies;
    float timer = 0;
    public Image healthBar;
    public float windowHealth = 100;

    void Update() {
        if (!GameController.Paused) {
            timer += Time.deltaTime;

            if (timer >= spawnRate) {
                SpawnEnemy();
                timer = 0;
            }
        }
        ShowHealth();

        if (windowHealth <= 0 && !GameController.Paused)
            GameController.ShowGameOver();
    }

    public void ShowHealth() {
        RectTransform rectTransform = (RectTransform)healthBar.transform;
        rectTransform.sizeDelta = new Vector2(windowHealth*4, 100);
    }

    void SpawnEnemy() {
        int rand = Random.Range(0, enemies.Length-1);
        float x = Random.Range(-1.5f, 2f);
        GameObject newEnemy = (GameObject)Instantiate(enemies[rand], new Vector3(x, 0, 1), Quaternion.identity, transform);
        newEnemy.transform.localPosition = new Vector3(x, 0, -1);
    }
}