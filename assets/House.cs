using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour {

    public GameObject current;
    Room r;
    GameObject p;
    public GameObject playerPre;
    public enum direction
    {
        up, down, left, right
    }
	// Use this for initialization
	void Start () {
        p= Instantiate(playerPre);
        r = current.GetComponent<Room>();
        r.Generate(p);
        transform.position = current.transform.position + new Vector3(r.width / 2f, r.height/ 2f, -20);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.W))
        {
            GameObject t =relativeTile(new Vector2(0, 1));
            if(t&& t.GetComponent<Tile>().isPassable)
            {
                playerMove(direction.up);
                r.tick();
            }
            
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            GameObject t = relativeTile(new Vector2(-1,0));
            if (t && t.GetComponent<Tile>().isPassable)
            {
                playerMove(direction.left);
                r.tick();
            }

        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            GameObject t = relativeTile(new Vector2(0, -1));
            if (t && t.GetComponent<Tile>().isPassable)
            {
                playerMove(direction.down);
                r.tick();
            }

        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            GameObject t = relativeTile(new Vector2(1,0));
            if (t && t.GetComponent<Tile>().isPassable)
            {
                playerMove(direction.right);
				p.GetComponent<Player>().tick ();
                r.tick();
            }

        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            if (p.GetComponent<Player>().water>0)
            {
                p.GetComponent<Player>().water--;
                for(int i = -1; i < 2; i++)
                {
                    for(int j=-1;j<2;j++)
                    {
                        GameObject t = relativeTile(new Vector2(i, j));
                        if (t)
                        {
                            t.GetComponent<Tile>().fire = -1;
                        }
                    }
                }
                p.GetComponent<Player>().tick();
                r.tick();
            }

        }

    }
    void playerMove(direction d)
    {
        GameObject t = p.GetComponent<Player>().tile;
        GameObject tile;
        switch (d)
        {
            case direction.up:
                tile = relativeTile(new Vector2(0, 1));
                p.GetComponent<Player>().tile = tile;
                p.transform.position = tile.transform.position;
                break;
            case direction.down:
                tile = relativeTile(new Vector2(0, -1));
                p.GetComponent<Player>().tile = tile;
                p.transform.position = tile.transform.position;
                break;
            case direction.left:
                tile = relativeTile(new Vector2(-1, 0));
                p.GetComponent<Player>().tile = tile;
                p.transform.position = tile.transform.position;
                break;
            case direction.right:
                tile = relativeTile(new Vector2(1, 0));
                p.GetComponent<Player>().tile = tile;
                p.transform.position = tile.transform.position;
                break;
        }

    }
    GameObject relativeTile(Vector2 d)
    {
        Vector3 c = d;
        Collider2D col = Physics2D.OverlapBox(p.transform.position + c, new Vector2(0.2f, 0.2f), 0);
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
