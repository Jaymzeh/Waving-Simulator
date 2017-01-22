using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WindowPan : MonoBehaviour {

    public bool isOver;
    public Vector3 direction;

	public void IsHovering(bool hover) {
        isOver = hover;
    }



    void Update() {
        if (isOver)
            UI.instance.PanWindows(direction);
    }
}
