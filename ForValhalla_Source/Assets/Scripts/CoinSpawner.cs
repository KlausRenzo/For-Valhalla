using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CoinSpawner : MonoBehaviour
{
    public int ASD;
    public int cointospwn;
    public int coinNumber;
    public int iteration;
    public GameObject coinObj;
    public GameObject coinObj_1;
    public GameObject coinObj_3;

    Animator anim;

    
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(draw());
    }

    // Update is called once per frame
    void Update()
    {

        // 	if (cointospwn > 0 && Input.GetButtonDown("k")){
        // 		GameObject coin = (GameObject)GameObject.Instantiate(coinObj, this.transform.position , new Quaternion(0,0,0,0));
        // 		cointospwn--;
        // 	}
        // if(Input.GetButtonDown("R")){

        // 	Vector3 posizione = this.transform.position + (new Vector3(Random.Range(-5,5),0,0));

        // 	GameObject coin = (GameObject)GameObject.Instantiate(coinObj, posizione , new Quaternion(0,0,0,0));
        // 		}

    }

IEnumerator draw() {
    while(true){
		spawnCoin();
		// Debug.Log(Time.time);
		yield return new WaitForSeconds(5F);
    }

}

private void spawnCoin()
    { // REMEMBER: tilesets are specular on x axis
        int type =  Random.Range(0,8);
        int[,] array = new int[5, 5];
        switch (type)
        {
            case 0:
                array = new int[5, 5] { {1,0,0,0,1},    //croce simmetrica
                                        {0,1,0,1,0},
                                        {0,0,2,0,0},
                                        {0,1,3,1,0},
                                        {1,0,1,0,1}};
                break;
            case 1:
                array = new int[5, 5] { {1,1,1,1,1},    //
                                        {0,0,0,0,0},
                                        {0,0,2,0,0},
                                        {0,1,0,1,0},
                                        {0,0,3,0,0}};
                break;
            case 2:
                array = new int[5, 5] { {1,0,0,0,0},    //Diagonale dx -> sx
                                        {0,2,0,0,0},
                                        {0,0,2,0,0},
                                        {0,0,0,2,0},
                                        {0,0,0,0,1}};
                break;
            case 3:
                array = new int[5, 5] { {0,0,0,0,1},    //Diagonale sx - dx
                                        {0,0,0,2,0},
                                        {0,0,3,0,0},
                                        {0,2,0,0,0},
                                        {1,0,0,0,0}};
                break;                
            case 4:
                array = new int[5, 5] { {0,1,0,0,0},    //solo Player 0
                                        {0,2,0,0,0},
                                        {0,3,0,0,0},
                                        {0,2,0,0,0},
                                        {0,1,0,0,0}};
                break;
            case 5:
                array = new int[5, 5] { {0,0,0,1,0},    //solo Player 1
                                        {0,0,0,2,0},
                                        {0,0,0,3,0},
                                        {0,0,0,2,0},
                                        {0,0,0,1,0}};
                break;
            case 6:
                array = new int[5, 5] { {0,0,3,0,0},    //singola moneta centrale
                                        {0,0,3,0,0},
                                        {0,0,3,0,0},
                                        {0,0,3,0,0},
                                        {0,0,3,0,0}};
                break;
            case 7:
                array = new int[5, 5] { {0,0,0,0,0},    //pattern vuoto
                                        {0,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0},
                                        {0,0,0,0,0}};
                break;
            case 8:
                array = new int[5, 5] { {0,0,0,0,0},    //pattern faccina
                                        {0,3,0,3,0},
                                        {0,0,1,0,0},
                                        {2,2,0,2,2},
                                        {0,0,2,0,0}};
                break;
        }
    for (int i =0 ; i<5; i++){
            for(int j=0; j<5; j++){
                Vector3 posizione = this.transform.position + (new Vector3(j*2.6F,i*2.6F,0));
                if (array[i, j] != 0)
                {
                    if (array[i, j] == 1)
                    {
                        GameObject coin = (GameObject)GameObject.Instantiate(coinObj, posizione, new Quaternion(0, 0, 0, 0));
                    }
                    else if (array[i, j] == 2)
                    {
                        GameObject coin = (GameObject)GameObject.Instantiate(coinObj_1, posizione, new Quaternion(0, 0, 0, 0));
                    }
                    else if (array[i, j] == 3)
                    {
                        GameObject coin = (GameObject)GameObject.Instantiate(coinObj_3, posizione, new Quaternion(0, 0, 0, 0));
                    }
                }
            }	
        }

    }
}





