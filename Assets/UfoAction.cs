using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class UfoAction : MonoBehaviour {

	public int ufoSpeed;
	public float bound;
	public float distance;
	public string direction = "";

	public Text lives;

	// Use this for initialization
	void Start () {
		setText ();
	}

	// Update is called once per frame
	void Update () {
		if (direction == "horizontal") {
			transform.position = new Vector3 (Mathf.PingPong (ufoSpeed * Time.time, bound) + distance, transform.position.y, transform.position.z);
		} 
		else if (direction == "vertical") {
			transform.position = new Vector3 (transform.position.x, Mathf.PingPong (ufoSpeed * Time.time, bound) + distance, transform.position.z);
		}
	}


	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.layer == 8) {
			Debug.Log ("DECETEDC");
			coll.gameObject.transform.position = new Vector3(0, 0, 0);
			//Destroy (coll.gameObject);
			Debug.Log(GlobalVars.LivesText);
			GlobalVars.LivesText--;

			if (GlobalVars.LivesText < 0) {
				Debug.Log ("Game Over");
				SceneManager.LoadScene("gameover");
			} 
			else {
				setText ();
			}

		
		}
	}

	void setText(){
		lives.text = "Lives: " + GlobalVars.LivesText.ToString();
	}



}
