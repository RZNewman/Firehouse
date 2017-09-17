using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

    public GameObject room;
    public GameObject thing = null;

	private const int FIRE_MAX = 5;
    public int fire = 0;
	// Use this for initialization
	void Start () {
		
	}
	public void tick()
    {
        if (thing)
        {
            thing.GetComponent<Thing>().tick();
        }
		if (this.fire > 0 && this.fire < FIRE_MAX) {
			this.fire += 1;
		} else if (this.fire == FIRE_MAX) {
			for (int x = 0; x < 2; x += 1) {
				for (int y = 0; y < 2; y += 1) {
					GameObject o = this.relativeTile (new Vector2 (x, y));
					Tile t = o.GetComponent<Tile> ();
					if (t != null && t.fire == 0 && (t.isFree || t.thing.GetComponent<Thing>().isFlamable)) {
						t.fire = 1;
					}
				}
			}
		}
		if (fire != 0) {
			GameObject f = transform.GetChild (0);
			f.SetActive (true);
			f.transform.localScale = Vector3.one * ((float)this.fire / (float) this.FIRE_MAX);
		}
    }
	// Update is called once per frame
	void Update () {
		
	}
    public bool isFree
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
    GameObject relativeTile(Vector2 dir)
    {
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
