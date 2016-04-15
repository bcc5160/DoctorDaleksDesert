using UnityEngine;
using System.Collections;

public class StartSpeech : MonoBehaviour {

	public bool startspeech = true;
	public GameObject bubble;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find ("Player").transform.position.x > 2) {
			startspeech = false;
		}

		if (startspeech == false)
			bubble.SetActive (false);
	
	}

}
