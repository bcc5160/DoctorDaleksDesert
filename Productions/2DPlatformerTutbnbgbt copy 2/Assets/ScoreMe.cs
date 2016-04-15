using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreMe : MonoBehaviour {

	public Text text;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		setText ();
		Debug.Log (text.text);
	}

	void setText(){
		if (GlobalVars.end == true) {
			text.text = GlobalVars.score.ToString();
		}
		else {
			text.text = "0";
		}
	}

}
