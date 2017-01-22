using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {
    GameObject[] backgrounds;
    public static UI instance;
    public Button teaParty;
    public Sprite partyOff, partyOn;
    public EnemySpawn[] spawners;
    public AudioClip teaClip;
    public ParticleSystem[] teaParticle;

    void Awake() {
        instance = this;
        instance.backgrounds = GameObject.FindGameObjectsWithTag("Background");
    }

    public void ChangeScene(string scene) {
        LoadingScreen.ChangeScene(scene);
    }

    void Update() {
        if (GameController.partyCounter >= GameController.partyTarget) {
            if (teaParty.image != partyOn) {
                teaParty.image.overrideSprite = partyOn;
                if (!teaParticle[1].isPlaying)
                teaParticle[1].Play();
            }
        }
        else
            if (teaParty != partyOff) {
            teaParty.image.overrideSprite = partyOff;
            

            if (teaParticle[1].isPlaying)
                teaParticle[1].Stop();
        }
    }


    public void TeaParty() {
        if (GameController.partyCounter >= GameController.partyTarget) {
            Debug.Log("PARTY!!!");
            GameController.partyCounter = 0;
            AudioControl.instance.PlayBossSFX(teaClip);
            teaParty.image.overrideSprite = partyOff;

             if (!teaParticle[0].isPlaying)
                teaParticle[0].Play();

            foreach(EnemySpawn spawner in spawners) {
                Enemy[] enemies = spawner.GetComponentsInChildren<Enemy>();
                foreach (Enemy enemy in enemies) {
                    enemy.satisfaction = enemy.targetSatisfaction * 2;
                }
            }
        }
    }

    public void ExitGame() {
        GameController.ExitGame();
    }

    public void PanWindows(Vector3 direction) {
        foreach(GameObject image in instance.backgrounds) {
            image.transform.Translate(direction);
        }
    }
}