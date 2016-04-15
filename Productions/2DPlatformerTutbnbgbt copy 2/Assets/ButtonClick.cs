using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ButtonClick : MonoBehaviour, IPointerClickHandler {

	public Button button;
	public bool restart = false;

	public void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Left) {
			if (restart == true) {
				Debug.Log ("Left click");
				SceneManager.LoadScene ("start");
			} 
			else {
				Debug.Log ("Left click");
				SceneManager.LoadScene ("init");
			}
		}
		else if (eventData.button == PointerEventData.InputButton.Middle)
			Debug.Log("Middle click");
		else if (eventData.button == PointerEventData.InputButton.Right)
			Debug.Log("Right click");
	}
}