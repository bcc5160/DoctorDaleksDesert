using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class JailWin : MonoBehaviour {

	public bool speechBubble = false;
	public bool thanksbubble = false;
	public GameObject quote;
	public GameObject thanks;

	// Use this for initialization
	void Start () {
		quote.SetActive(true);
		thanks.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.FindGameObjectWithTag("Player").transform.position.x > 175) {
			speechBubble = true;
		}
		if (speechBubble == true) {
			quote.SetActive(true);
		}
	}

	IEnumerator OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.layer == 8) {
			Debug.Log ("DECETEDC");
			transform.position = new Vector3(Mathf.Lerp(transform.position.x, transform.position.y + 10, Time.time), 0, 0);
			speechBubble = false;
			quote.SetActive (false);
			thanks.SetActive (true);
			GlobalVars.end = true;
			yield return new WaitForSeconds(3);
			SceneManager.LoadScene ("gameover");
		}

	}




}
