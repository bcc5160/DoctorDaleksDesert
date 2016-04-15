using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UfoAction : MonoBehaviour {

	public int ufoSpeed;
	public float bound;
	public float distance;
	public string direction = "";

	public Text my_text;


	// Use this for initialization
	void Start () {
		my_text = GameObject.Find("Lives").GetComponent<Text>();
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

			if (my_text.text == "Lives: 3") {
				Debug.Log ("Lives 3");
				my_text.text = "Lives: 2";
			} 
			else if (my_text.text == "Lives: 2") {
				Debug.Log ("Lives 2");
				my_text.text = "Lives: 1";
			}
			else{
				my_text.text = "Lives: 0";
			}
		}

	}

}
