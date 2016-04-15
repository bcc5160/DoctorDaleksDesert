using System;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace UnityStandardAssets.CrossPlatformInput
{
    public class ButtonHandler : MonoBehaviour
    {

        public string Name;
		public bool clicked = false;


        void OnEnable()
        {

        }

		public void onMouseDown(){
			Debug.Log ("clicked");
			SceneManager.LoadScene ("init");
		}

        public void SetDownState()
        {
            CrossPlatformInputManager.SetButtonDown(Name);
			clicked = true;
        }


        public void SetUpState()
        {
            CrossPlatformInputManager.SetButtonUp(Name);
			clicked = true;
        }


        public void SetAxisPositiveState()
        {
            CrossPlatformInputManager.SetAxisPositive(Name);
        }


        public void SetAxisNeutralState()
        {
            CrossPlatformInputManager.SetAxisZero(Name);
        }


        public void SetAxisNegativeState()
        {
            CrossPlatformInputManager.SetAxisNegative(Name);
        }

        public void Update()
        {
			

			if(clicked == true)
				SceneManager.LoadScene ("init");
        }
    }
}
