using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    Animator anim;
    public GameObject pSys;
    Collider2D myColl;
    public int myPoints;
    float vel;
    public Transform SpawnPos;
    public AudioClip Sound;
    AudioSource audioScr;
    AudioListener audiolistener;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        myColl = GetComponent<Collider2D>();
        vel = GameController.velocity;
        audioScr = GetComponent<AudioSource>();
       
        
	}
	
	// Update is called once per frame
	void Update () {
        
        gameObject.transform.position += new Vector3(0, vel*Time.deltaTime, 0);
        if(transform.position.y > SpawnPos.position.y ){
        	KillMe();
        }
    }


   
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            anim.SetTrigger("GotIt");
            myColl.enabled = false;
            PlayerController play = other.gameObject.GetComponent<PlayerController>();
            Points(play, myPoints);
            audioScr.Play();
            
        }

    }

    void ParticleTrigger() {

        pSys.SetActive(true);
            }

    void Points(PlayerController player, int i) {

        player.GotPoints(i);
    }

    void KillMe()
    {
        GameController.lostPoints += myPoints;
        DestroyObject(gameObject);

    }
}
