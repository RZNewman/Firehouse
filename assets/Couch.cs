using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Couch : Thing {


	// Use this for initialization
	void Start () {
		this.isPassable = false;
		this.isFlamable = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void tick() {}
}
