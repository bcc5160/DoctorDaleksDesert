using UnityEngine;
using System.Collections;

public class GlobalVars : MonoBehaviour {

	public static int LivesText = 3;
	public static float score = 0f;
	public static bool end = false;

	// Use this for initialization
	void Start () {
		GUI.Label(new Rect(10, 10, 100, 20), "Hello World!"); 
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
