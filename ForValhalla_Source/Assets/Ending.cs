using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Ending : MonoBehaviour {

    public Camera cam;
	// Use this for initialization
	void Start () {
        cam.enabled = false;
        StartCoroutine("RestartCam");
	}
	
	// Update is called once per frame
	void Update () {



    }

    IEnumerator RestartCam() {
        yield return new WaitForSeconds(0.3f);
        cam.enabled = true;
    }
    public void PlaySound() {

        GetComponent<AudioSource>().Play();

    }


}
