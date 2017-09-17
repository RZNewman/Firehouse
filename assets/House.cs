using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour {

    public Room current;
    GameObject p;
    public GameObject playerPre;
    public enum direction
    {
        up, down, left, right
    }
	// Use this for initialization
	void Start () {
        p= Instantiate(playerPre);
        current.GetComponent<Room>().Generate(p);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.W))
        {
            playerMove(direction.up);
        }
	}
    void playerMove(direction d)
    {
        GameObject t = p.GetComponent<Player>().tile;
        switch (d)
        {
            case direction.up:
                GameObject tile = relativeTile(new Vector2(0, 1));
                p.GetComponent<Player>().tile = tile;
                p.transform.position = tile.transform.position;
                break;
        }

    }
    GameObject relativeTile(Vector2 d)
    {
        Vector3 c = d;
        return Physics2D.OverlapBox(p.transform.position + c, new Vector2(0.2f, 0.2f), 0).gameObject;
    }
}
