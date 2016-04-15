using UnityEngine;
using System.Collections;

public class Parallaxing : MonoBehaviour {


	public Transform[] backgrounds;   // Array that will store elements we will allow paralaxing to (background and foreground -- inhibit movement?)
	private float[] parallaxScales;    // Array to store parallex scale -- automate so we dont have to apply values to all elements -- no guess how far back (The proportion of the camera's movement to move the backgrounds by)
	public float smoothing = 1f;          // How smooth paralax will be and smooth > 0
	private Transform cam;			  // This is a reference to the main camera's transform
	private Vector3 previousCamPos;   // Tuplet (x,y,z) previous camera position (store position of camera in previous frame) --- Used to calculate paralax

	// Is called before Start(). Great for reference
	void Awake() {
		// Set up camera reference
		cam = Camera.main.transform;
	}

	// Use this for initialization
	void Start () {
		// Initialize the different variables
		// The previous frame had the current frame's camera posiition
		previousCamPos = cam.position;

		// Loop through array and initialize every element to a paralax scale (Length is same as backgrounds)
		parallaxScales = new float[backgrounds.Length];

		// iterate through backgrounds array and assigning corresponding background position to parallax scales
		for (int i=0; i < backgrounds.Length; i++) {
			parallaxScales[i] = backgrounds [i].position.z * -1;
		}
	}

	// Update is called once per frame (logic)
	void Update () {
		// Set each 
		for (int i = 0; i < backgrounds.Length; i++) {
			// the parallax is the opposite of the camera movement because the previous frame multiplied by the scale --- (prev-new) * scale
			float parallax = (previousCamPos.x - cam.position.x) * parallaxScales[i];

			// set a target x position which is the current position plus the parallax (parallax to actual position)
			float backgroundTargetPosX = backgrounds[i].position.x + parallax;

			// create a target position which is the background's current position with the target's position
			// X then same y and same z
			Vector3 backgroundTargetPos = new Vector3 (backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

			// fade between current position and the target position using lerp
			backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
		}

		// Set the previousCamPos to the camera's position at the end of the frame
		previousCamPos = cam.position;
	}
}
