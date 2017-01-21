﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float satisfaction;
    public int targetSatisfaction = 100;
    public float speed = 1;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (satisfaction >= targetSatisfaction)
            Destroy(gameObject);

        transform.Translate(0, -speed,-speed*0.001f);
        transform.localScale += (Vector3.one * 0.0005f);
	}
}
