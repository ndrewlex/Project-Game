﻿using UnityEngine;
using System.Collections;

public class DestroyScript : MonoBehaviour {

	public float destroyTime;
	private SpawnItems spawn;
	// Use this for initialization
	void Start () {
		Destroy (gameObject, destroyTime);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
