using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour {

    public int width, height;
    public GameObject tilePre;
    
    public Vector2 entry;
	// Use this for initialization
	public void Generate (GameObject player) {
		for(int i =0; i<width; i++)
        {
            for(int j=0; j<height; j++)
            {
                //print(i + "--" + j);
                GameObject t =Instantiate(tilePre, transform.position + new Vector3(i, j), transform.rotation, transform);
                t.GetComponent<Tile>().room = gameObject;
				if (Random.value > 0.9) {
					t.GetComponent<Tile> ().fire = 1;
				}
				t.GetComponent<Tile> ().render_setup ();
                
            }
        }
        placePlayer(player);
	}
    public void tick()
    {
		foreach (Tile tile in this.GetComponentsInChildren<Tile>()) {
			tile.tick ();
		}
		foreach (Tile tile in this.GetComponentsInChildren<Tile>()) {
			tile.render_setup ();
		}
    }
	// Update is called once per frame
	void Update () {
		
	}
    public GameObject tileAtLoc(Vector2 l)
    {
        Vector3 loc = l;
        Collider2D col;
        col = Physics2D.OverlapBox(transform.position +loc, new Vector2(0.2f, 0.2f), 0);
        return col.gameObject;
    }
    public void placePlayer(GameObject p)
    {
        GameObject start = tileAtLoc(entry);
        p.GetComponent<Player>().tile = start;
    }
}
