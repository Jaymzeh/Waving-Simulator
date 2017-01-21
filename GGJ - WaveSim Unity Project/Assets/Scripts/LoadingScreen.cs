using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour {

    public static LoadingScreen instance;
    GameObject background;
    Text text;
    int progress = 0;

	void Awake() {
        if (instance == null) {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != this)
            Destroy(gameObject);

        text = GetComponentInChildren<Text>();
        background = transform.FindChild("Background").gameObject;
        background.SetActive(false);
        text.gameObject.SetActive(false);
        
    }

    public static void ChangeScene(string scene) {
        instance.StartCoroutine("LoadScene", scene);
    }

    IEnumerator LoadScene(string scene) {

        background.SetActive(true);
        text.gameObject.SetActive(true);

        AsyncOperation async = SceneManager.LoadSceneAsync(scene);
        while (!async.isDone) {
            progress = (int)(async.progress * 100);
            text.text = "Progress: " + progress + "%";
            
            yield return null;
        }
        background.SetActive(false);
        text.gameObject.SetActive(false);
        GameController.Paused = false;
    }
}
