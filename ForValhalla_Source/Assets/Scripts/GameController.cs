using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public static int move = 0;
    WaitForSeconds waitStep = new WaitForSeconds(2);
    public GameObject[] players;
    PlayerController[] playerCtrl;
    public Camera camera_0;
    public Camera camera_1;

    public int P0points = 0;
    public int P1points = 0;


    public int p0moving = 0;
    public int p1moving = 0;

    public float posStep = 1;
    public static int lostPoints = 0;
    public static float velocity = 3;

    public Text P0point;
    public Text P1point;
    public Text c1P0point;
    public Text c1P1point;


    Vector3 line;

    // Use this for initialization
    void Start() {
        StartCoroutine("TimeStep");
        players = GameObject.FindGameObjectsWithTag("Player");
        playerCtrl = new PlayerController[] { players[0].GetComponent<PlayerController>(), players[1].GetComponent<PlayerController>()};
        line = new Vector3(0, transform.position.y, 0);
    }
	
	// Update is called once per frame
	void Update () {
        
	}


    IEnumerator TimeStep()
    {

        if (move > 0)
        {
            Move(Vector3.right * posStep);
            if (p0moving > p1moving) Skol(true); else Skol(false);

        }
        else if (move < 0)
        {
            Move(Vector3.left * posStep);
            if (p0moving < p1moving) Skol(true); else Skol(false);
        }
        move = 0;
        p0moving = 0;
        p1moving = 0;
        yield return waitStep;
        StartCoroutine("TimeStep");
    }


    void Move(Vector3 v)
    {
        for (int i = 0; i < players.Length; i++) {
            
                players[i].transform.position += v;
                
            if (i==0)
                players[0].transform.position = new Vector3(Mathf.Clamp(players[0].transform.position.x, -4.8f, 0.93f), players[0].transform.position.y, 0);
            else
                players[1].transform.position = new Vector3(Mathf.Clamp(players[1].transform.position.x, -0.93f, 4.8f), players[1].transform.position.y, 0);
        }


    }


    void Skol(bool bP0) {

        if (bP0) {

            playerCtrl[0].SkolAnim.SetTrigger("SkolTrigger");
            players[0].GetComponent<AudioSource>().Play();
        }
        else
        {

            playerCtrl[1].SkolAnim.SetTrigger("SkolTrigger");
            players[1].GetComponent<AudioSource>().Play();


        }


    }
    

    public void UpdatePoints(bool bP0, int p) {

        if (bP0)
        {

            P0points += p;
            P0point.text = P0points.ToString();
            c1P0point.text = P0points.ToString();

        }
        else {

            P1points += p;
            P1point.text = P1points.ToString();
            c1P1point.text = P1points.ToString();

        }


    }
}
