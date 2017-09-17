using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour {

    public GameObject current;
    Room r;
    GameObject p;
    public GameObject playerPre;
    public GameObject roomPre;
    public enum direction
    {
        up, down, left, right, none
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
        direction leave = direction.none;
        GameObject tileOn = p.GetComponent<Player>().tile.GetComponent<Tile>().thing;
        if (tileOn && tileOn.GetComponent<Door>())
        {
            Door door = tileOn.GetComponent<Door>();
            //print(door.dir);
            leave = door.dir;
        }


        if (Input.GetKeyDown(KeyCode.W))
        {
            GameObject t =relativeTile(new Vector2(0, 1));
            if(t&& t.GetComponent<Tile>().isPassable)
            {
                playerMove(direction.up);
                r.tick();
            }
            else if (leave == direction.up)
            {
                nextRoom(leave);
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
            else if (leave == direction.left)
            {
                nextRoom(leave);
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
            else if (leave == direction.down)
            {
                nextRoom(leave);
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
            else if (leave == direction.right)
            {
                nextRoom(leave);
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
    void nextRoom(direction d)
    {
        
        GameObject next = Instantiate(roomPre);
        r = next.GetComponent<Room>();
        Vector2 v=r.DoorWall(opp(d));
        r.entry = v;
        r.Generate(p);
        Destroy(current);
        current = next;
        transform.position = current.transform.position + new Vector3(r.width / 2f, r.height / 2f, -20);
    }
    direction opp(direction d)
    {
        switch (d)
        {
            case direction.up:
                return direction.down;
                
            case direction.down:
                return direction.up;
                
            case direction.left:
                return direction.right;
                
            case direction.right:
                return direction.left;

            default:
                throw new MissingReferenceException();
                
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
