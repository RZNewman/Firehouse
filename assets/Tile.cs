using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

    public GameObject room;
    public GameObject thing = null;

    public float fire;
	// Use this for initialization
	void Start () {
		
	}
	public void tick()
    {
        if (thing)
        {
            thing.GetComponent<Thing>().tick();
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
    bool isFree
    {
        get
        {
            return thing == null;
        }
    }
    bool isPassable
    {
        get
        {
            if (thing)
            {
                return thing.GetComponent<Thing>().isPassable;
            }
            else
            {
                return true;
            }
        }
    }
}
