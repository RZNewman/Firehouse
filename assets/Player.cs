using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public GameObject tile;
	public int health = 10;
    public int water = 6;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void tick() {
		if (this.tile.GetComponent<Tile> ().fire != 0) {
			health -= 1;
		}
		if (health <= 0) {
			this.gameObject.SetActive (false);
			print ("DEAD");
		}
	}
}
