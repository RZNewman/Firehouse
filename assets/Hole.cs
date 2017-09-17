using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : Thing {

	// Use this for initialization
	void Start () {
		this.isPassable = false;
		this.isFlamable = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void tick(){}
}
