using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Timer : MonoBehaviour {

	float timeLeft = 200.0f;

	public Text text;



	void Update()
	{
		timeLeft -= Time.deltaTime;
		GlobalVars.score = (float)timeLeft;
		Debug.Log (GlobalVars.score);
		text.text = "Time Left:" + Mathf.Round(timeLeft);
		if(timeLeft < 0)
		{
			SceneManager.LoadScene("gameover");
		}

	}
}
