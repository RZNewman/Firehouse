using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour {

    public int width, height;
    public GameObject tilePre;
    public GameObject doorPre;
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
        genDoors();
    }
    public void tick()
    {
		foreach (Tile tile in this.GetComponentsInChildren<Tile>()) {
			tile.tick ();
		}
        foreach (Tile tile in this.GetComponentsInChildren<Tile>())
        {
            tile.regFire();
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
    public void genDoors()
    {
        int numDoors = Mathf.FloorToInt(Random.Range(3, 4));
        for (int i = 0; i < numDoors; i++)
        {
            GameObject d = null;
            while (!d)
            {
                House.direction dir = randomDir();
                print(dir);
                Vector3 loc = DoorWall(dir);
                print(loc);
                GameObject t = tileAtLoc(loc);

                if (!t.GetComponent<Tile>().thing)
                {
                    d = Instantiate(doorPre, t.transform.position, transform.rotation);
                    d.GetComponent<Thing>().tile = t;
                    t.GetComponent<Tile>().thing = d;
                    d.GetComponent<Door>().dir = dir;
                    if (dir == House.direction.left || dir == House.direction.right)
                    {
                        d.transform.rotation = Quaternion.Euler(0, 0, 90);
                        if (dir == House.direction.left)
                        {
                            d.transform.position += Vector3.right * -0.5f;

                        }
                        else
                        {
                            d.transform.position += Vector3.right * 0.5f;

                        }
                    }
                    else
                    {

                        if (dir == House.direction.up)
                        {
                            d.transform.position += Vector3.up * 0.5f;

                        }
                        else
                        {
                            d.transform.position += Vector3.up * -0.5f;

                        }
                    }

                }
            }
        }
    }
    Vector2 DoorWall(House.direction d)
    {
        int x, y;
        if (d == House.direction.up || d == House.direction.down)
        {
            x = Mathf.FloorToInt(Random.Range(1, width - 1));
            if (d == House.direction.up)
            {
                y = height - 1;

            }
            else
            {
                y = 0;

            }
        }
        else
        {
            y = Mathf.FloorToInt(Random.Range(1, height - 1));
            if (d == House.direction.right)
            {
                x = width - 1;

            }
            else
            {
                x = 0;

            }
        }
        return new Vector2(x, y);
    }
    House.direction randomDir()
    {
        int r = Mathf.FloorToInt(Random.Range(0, 4));
        if (r == 0)
        {
            return House.direction.up;
        }
        else if (r == 1)
        {
            return House.direction.down;
        }
        else if (r == 2)
        {
            return House.direction.left;
        }
        else
        {
            return House.direction.right;
        }
    }
}
