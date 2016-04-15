using UnityEngine;
using System.Collections;

public class Dalek1Actions : MonoBehaviour {

	public int dalekSpeed; 			    // speed of a dalek
	public int dalekDirection = 1;		// Dalek direction
	public float leftBound;
	public float rightBound;
	public bool surprise;
	private bool dalekMove = false; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//transform.Translate (new Vector3(dalekSpeed, 0, 0) * Time.deltaTime);
		//OnCollisionEnter2D ();
		if (surprise == false)
			transform.position = new Vector3 (Mathf.PingPong (dalekSpeed * Time.time, rightBound) + leftBound, transform.position.y, transform.position.z);
		else {
			if (GameObject.FindGameObjectWithTag ("Player").transform.position.x > 80) {
				dalekMove = true;
			}
			if (dalekMove == true) {
				transform.position = new Vector3 (Mathf.PingPong (dalekSpeed * Time.time, rightBound) + leftBound, transform.position.y, transform.position.z);
			}
		}
	}


	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.layer == 8) {
			Debug.Log ("DECETEDC");
			coll.gameObject.transform.position = new Vector3(0, 0, 0);
			//Destroy (coll.gameObject);
		}

	}
	
	
}
