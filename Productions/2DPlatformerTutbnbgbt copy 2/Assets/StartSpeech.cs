using UnityEngine;
using System.Collections;

public class StartSpeech : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.FindGameObjectWithTag ("Player").transform.position.x < 10) {
			GameObject.FindGameObjectWithTag ("begin").SetActive (true);
		} else {
			GameObject.FindGameObjectWithTag ("begin").SetActive (false);
		}
	
	}

}
