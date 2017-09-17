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
     public bool isPassable
    {
        get
        {
			return (thing == null) || thing.GetComponent<Thing>().isPassable;
        }
    }
    GameObject relativeTile(House.direction d)
    {
        Vector2 dir;
        switch (d)
        {
            case House.direction.up:
                dir = new Vector2(0, 1);
                break;
            case House.direction.down:
                dir = new Vector2(0, -1);
                break;
            case House.direction.left:
                dir = new Vector2(-1, 0);
                break;
            case House.direction.right:
                dir = new Vector2(1, 0);
                break;
            default:
                dir = Vector2.zero;
                break;
        }
        Vector3 c = dir;
        Collider2D col = Physics2D.OverlapBox(transform.position + c, new Vector2(0.2f, 0.2f), 0);
        if (!col)
        {
            return null;
        }
        else
        {
            return col.gameObject;
        }

    }
}
