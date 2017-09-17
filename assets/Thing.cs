using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Thing: MonoBehaviour {

    public GameObject tile;
	// Use this for initialization
	void Start () {
		
	}
    public abstract void tick();
	
	// Update is called once per frame
	void Update () {
		
	}
    public bool isPassable;
}
