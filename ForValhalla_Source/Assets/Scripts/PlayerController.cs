using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour {


    public bool bP0 = false;
    GameController gameCtrl;

    public Animator SkolAnim;
    public Animator FaceAnim;

    // Use this for initialization
    void Start() {

        gameCtrl = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        
    }

    // Update is called once per frame
    void Update() {

        if (bP0)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                GameController.move++;
                gameCtrl.p0moving++;
                FaceAnim.SetTrigger("AngryTrigger");
            }
            if (Input.GetKeyDown(KeyCode.A))
            {

                GameController.move--;
                gameCtrl.p0moving--;
                FaceAnim.SetTrigger("AngryTrigger");
            }

        }
        else
        {

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                GameController.move++;
                gameCtrl.p1moving++;
                FaceAnim.SetTrigger("AngryTrigger");
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                GameController.move--;
                gameCtrl.p1moving--;
                FaceAnim.SetTrigger("AngryTrigger");
            }

        }
    }

    public void GotPoints(int points) {

        gameCtrl.UpdatePoints(bP0, points);

    }

    

    
}
