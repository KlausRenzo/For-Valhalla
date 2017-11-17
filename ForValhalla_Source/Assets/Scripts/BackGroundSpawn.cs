using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundSpawn : MonoBehaviour {

  //  GameController gameCtrl;
    float vel;
    SpriteRenderer spr;
    public Transform pos;

	// Use this for initialization
	void Start () {

      //  gameCtrl = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

        vel = GameController.velocity;
        spr = GetComponent<SpriteRenderer>();
       
        
	}
	
	// Update is called once per frame
	void Update () {

        transform.position += Vector3.up * vel * Time.deltaTime;

        if (transform.position.y > pos.position.y)
        {
            transform.position = -pos.position;


        }

    }
}
