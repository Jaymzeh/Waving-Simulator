using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeToGameScene : MonoBehaviour {

    public void ChangeScene()
    {
        GameController.ChangeScene("Street");
    }
}
