using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour {

    public Text scoreText, highScoreText;

    void Start() {
        if (highScoreText != null)
            GameController.highScore = GameController.ReadHighScore();
    }
	
	// Update is called once per frame
	void Update () {
        if (scoreText != null)
            scoreText.text = "Score: " + GameController.score.ToString();

        if (highScoreText != null)
            highScoreText.text = "Highscore: " + GameController.highScore.ToString();
	}
}
