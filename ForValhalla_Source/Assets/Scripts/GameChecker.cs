using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameChecker : MonoBehaviour {

	public GameController GameCrtl; //used to get variables to check conditions

	public int gameState;
	public bool[] cheatArray = new bool[10];
	public int pointDifference; //EXAMPLE: point difference between P1 and P2
	public float P1LastInput; // Time.time last input was recieved
	public float P1SinceLastInput; // seconds since last input recieved
	public float P2LastInput;  
	public float P2SinceLastInput;
    public List<string> listaCheats;
    public List<string> listaPraise;
    public Animator P0CheatAnim;
    public Animator P1CheatAnim;
    public Text P0CheatText;
    public Text P1CheatText;
    bool bCanCheat = true;
    int i = 0;
    AudioSource audioSrc;
    public GameObject Ending;

    // Use this for initialization
    void Start () {
		for( int i =0; i<cheatArray.Length; i++){ // cheat array initializer
			cheatArray[i] = false;
		}
		gameState = 0;
        audioSrc = GetComponent<AudioSource>();
		// StartCoroutine(calculator()); // maybe not needed to check. need realtime w/ Update()
		StartCoroutine(cheatCondition());
        //StartCoroutine(winCondition());
        StartCoroutine(cheatRequest());
    }

	// Update is called once per frame
	void Update () {
		pointDifference = GameCrtl.P0points - GameCrtl.P1points;
		if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) ){ P1LastInput = Time.time; }
			P1SinceLastInput = Time.time - P1LastInput;
		if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow) ){ P2LastInput = Time.time; }
			P2SinceLastInput = Time.time - P2LastInput;
		
		if ((Time.time >= 60f && Time.time < 120f) || (Mathf.Max(GameCrtl.P1points, GameCrtl.P0points) >= 100 && Mathf.Max(GameCrtl.P1points, GameCrtl.P0points) < 500)){
			gameState = 1; //early game
		}
		if ((Time.time >= 120f && Time.time < 180f) || (Mathf.Max(GameCrtl.P1points, GameCrtl.P0points) >= 500 && Mathf.Max(GameCrtl.P1points, GameCrtl.P0points) < 1000)){
			gameState = 2; //mid game
		}
		if ((Time.time >= 180f && Time.time < 240f) || (Mathf.Max(GameCrtl.P1points, GameCrtl.P0points) >= 1000 && Mathf.Max(GameCrtl.P1points, GameCrtl.P0points) < 2000)){
			gameState = 3; // end game
		}

        if (Input.GetKeyDown(KeyCode.Space)) P0CheatAnim.SetTrigger("CheatTrigger");

    }

	IEnumerator cheatCondition(){
		while(true)	{ // check for game running
			cheatRequest();
			yield return new WaitForSeconds(0.5F);
		}
	}

	IEnumerator winCondition(){
		while(true)	{ // check for game running
			winRequest();
			yield return new WaitForSeconds(0.5F);
		}	

	}



	IEnumerator cheatRequest(){

        P1CheatText.text = listaCheats[i];
        P0CheatText.text = listaPraise[i];
        P1CheatAnim.SetTrigger("CheatTrigger");
        P0CheatAnim.SetTrigger("CheatTrigger");
        audioSrc.Play();
        yield return new WaitForSeconds(8f);
        P0CheatAnim.SetTrigger("CheatFinish");
        P1CheatAnim.SetTrigger("CheatFinish");
        yield return new WaitForSeconds(14f);
        if (i < listaCheats.Count-1)
        {
            i++;
            StartCoroutine("cheatRequest");
        }
        else
        {

            Ending.SetActive(true);
        }
        //if (bCanCheat)
        //{
        //    // @ 15 pointDifference, @ GS = 0, print message
        //    if (gameState == 0 && Mathf.Abs(pointDifference) >= 15 && !cheatArray[0])
        //    { //changed
        //        cheatCall(0);
        //    }

        //    // @ 30 pointDifference, @ GS = 0,1, print message + quest
        //    if (gameState <= 1 && Mathf.Abs(pointDifference) >= 30 && !cheatArray[1])
        //    {
        //        cheatCall(1);
        //    }

        //    // @ pD > 100, @ GS = 2
        //    if (gameState == 1 && Mathf.Abs(pointDifference) >= 100 && !cheatArray[2])
        //    {
        //        cheatCall(2);
        //    }

        //}

	}
	private void cheatCall(int cheatType){
		bool p0IsCheating = false;
		float timeLimit = -1f;
        bCanCheat = false;

		switch (cheatType){
			case 0:	//explanation for those insignificant mortal that cannot understand simple code!
				timeLimit=10f; //if timelimit is negative, just display, not using Coroutine; 
				print("cheat #0 in corso");

                
                cheatArray[cheatType] = true;
				break;

			case 1:	//explanation for those insignificant mortal that cannot understand simple code!
				timeLimit= 10f; //first use of timeLimit, testing with 5 second time
				print("cheat #1 in corso");

               
                cheatArray[cheatType] = true;

                //ADD CheatMessage
                break;

			case 2:
				timeLimit= 2000f;
				print("cheat #2 in corso");
				print("Premi (tasto cheat casuale) per guadagnare il favore degli Dei!"); //cheatMessage
				//p0IsCheating = (GameCrtl.P0points > GameCrtl.P1points)?false:true;
				cheatArray[cheatType] = true;
				break;
			case 3:
				break;
			case 4:
				break;
			default: print("How did u get here?!?"); break;

                 
			}

        CheckState(cheatType);

        if (timeLimit >=0 ){
			StartCoroutine(cheatAccomplished(cheatType, timeLimit, p0IsCheating)); //maybe is useless...
		}

		

	}


	IEnumerator cheatAccomplished(int cheatType, float timeLimit, bool p0){
		bool isCheatAccomplished = false;

        while (timeLimit > 0 && !isCheatAccomplished)
        {
            // if(Input.GetKeyDown(KeyCode.R)){isCheatAccomplished = true;}
            timeLimit -= Time.deltaTime;
            print(timeLimit);
            // if(cheatType == 0){}
            // if(cheatType == 1){	
            // 	}
            // if(cheatType == 2){}
            // if(cheatType == 3){}



            switch (cheatType)
            {
                case 0:
                    // it's not used
                    break;

                case 1:
                    // check if has ben done quest, and give rewards
                    // isCheatAccomplished = true;
                    if (Input.GetKeyDown(KeyCode.RightArrow)) { isCheatAccomplished = true; yield break; }
                    break;
                case 2:

                    if (Input.GetKeyDown(KeyCode.RightArrow)) { isCheatAccomplished = true; }
                    if ((Input.GetKeyDown(KeyCode.UpArrow) && p0) || (Input.GetKeyDown(KeyCode.W) && !p0))
                    {
                        isCheatAccomplished = true;
                        yield break;
                    }
                    break;
                case 3:
                    break;
                case 4:
                    break;
                default:
                    print("How did u get here?!?"); break;
                    yield return 0;
            }
            yield return new WaitForEndOfFrame();
        }
        yield return null;
        print("quest complete");
            P0CheatAnim.SetTrigger("CheatFinish");
            P1CheatAnim.SetTrigger("CheatFinish");
        

        bCanCheat = true;
    }

    void CheckState(int i) {

        if (GameCrtl.P0points > GameCrtl.P1points)
        {

            P1CheatText.text = listaCheats[i];
            P0CheatText.text = listaPraise[i];
            P1CheatAnim.SetTrigger("CheatTrigger");
            P0CheatAnim.SetTrigger("CheatTrigger");



        } //ADD CheatMessage
        else { 
        

            P0CheatText.text = listaCheats[i];
            P1CheatText.text = listaPraise[i];
            P0CheatAnim.SetTrigger("CheatTrigger");
            P1CheatAnim.SetTrigger("CheatTrigger");

        }

    }









/**//**//**//**//**//**//**//**//**//**//**//**//**//**//**/
	private void winRequest(){
		int pD = Mathf.Abs(pointDifference);
		int CoinDelivered = GameCrtl.P0points;//TOCHANGE!!!!!!!!!! in something to get number of coin passed!
		
		if(CoinDelivered > 2000){
			// first win condition stage
		}

		
		// called every 0.5 s to check if win condition are met
		// if(/*wincondition*/){
		// 	called if win condition are met
		// 	winCall(0/*winType*/);
		// }

		if(pD <= 100){ // finale collaborativo
			winCall(0);
		}

		if(pD <= 499 && pD >= 101){ // finale intermedio
			winCall(1);
		}

		if(pD >= 500){ // finale Egoistico
			winCall(2);
		}
		
		
	}
	private void winCall(int winType){
		//called if wincondition is met, and have to chage gamestate to GameOver->Win
		switch (winType){
			case 0:	// finale collaborativo
				print("finale Collaborativo");
				break;
			case 1: // finale intermedio
				print("finale Intermedio");
				break;
			case 2: // finale Egoistico
				print("finale Egoistico");
				break;
			default: print("How did u get here?!?"); break;
					}
	}

    



}
