using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Thing {
    public House.direction dir;
	// Use this for initialization
	void Start () {
        isPassable = true;
        isFlamable = true;
	}
    public override void tick()
    {
        
    }
    // Update is called once per frame
    void Update () {
		
	}
}
