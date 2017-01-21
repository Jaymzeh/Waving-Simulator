using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour {

    public Vector2 boundaries;

    void Update() {
        float x = Mathf.Clamp(transform.localPosition.x, -boundaries.x, boundaries.x);
        float y = Mathf.Clamp(transform.localPosition.y, -boundaries.y, boundaries.y);
        transform.localPosition = new Vector3(x,y,transform.localPosition.z);
    }
}
