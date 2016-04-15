using UnityEngine;
using System.Collections;

// Only use this script with sprite renderer
[RequireComponent (typeof (SpriteRenderer))]

public class Tiling : MonoBehaviour {

	public int offsetX = 2; 			// camera frame is like 2 level to right so that body is there (no real weird errors)
	public bool hasARightBody = false; 	// Do we need to do calculation if we have a body?
	public bool hasALeftBody = false;   // Check instantiation
	public bool reverseScale = false;	// used if object is not scalable

	private float spriteWidth = 0f;		// the width of our element
	private Camera cam;
	private Transform myTransform; 

	// Run before Start()
	void Awake(){
		cam = Camera.main;
		myTransform = transform;
	}

	// Use this for initialization
	void Start () {
		SpriteRenderer sRenderer = GetComponent<SpriteRenderer> (); // Only want one sprite renderer
		spriteWidth = sRenderer.sprite.bounds.size.x; 				// Width of element no matter how you size it
	}
	
	// Update is called once per frame
	void Update () {
		if (hasALeftBody == false || hasARightBody == false) {
			// Calculate the cameras extend (half the width) of what the camera can see in world coordinates
			float camHorizontalExtend = cam.orthographicSize * Screen.width / Screen.height; // center of camera to right bar

			// Calculate the x position where the camera can see the edge of the sprite (element)
			float edgeVisiblePositionRight = (myTransform.position.x + spriteWidth/2) - camHorizontalExtend; // position of intersection
			float edgeVisiblePositionLeft = (myTransform.position.x - spriteWidth/2) + camHorizontalExtend; 

			// Check if position of camera is >= ground - offset (so no weird errors where gets instantiated too late)
			// Check if we can see the edge of the element and then calling MakeNewBuddy if we cannot
			if (cam.transform.position.x >= edgeVisiblePositionRight - offsetX && hasARightBody == false) {
				// Add to right
				MakeNewBuddy(1);
				hasALeftBody = true;
			} 
			else if (cam.transform.position.x <= edgeVisiblePositionLeft + offsetX && hasALeftBody == false) {
				MakeNewBuddy (-1);
				hasARightBody = true;
			}
				
		}
	}

	// right or left =? 1/-1 value
	// A function that creates a buddy on the side required
	void MakeNewBuddy(int rightOrLeft){
		// Calculate new position for buddy
		Vector3 newPosition = new Vector3 (myTransform.position.x + spriteWidth * rightOrLeft, myTransform.position.y, myTransform.position.z);
		// Instantiating a new buddy and storing him in a variable
		Transform newBuddy = Instantiate (myTransform, newPosition, myTransform.rotation) as Transform; // clone of object

		// if not tilable, reverse x to get rid of ugly seams
		if (reverseScale == true) {
			newBuddy.localScale = new Vector3 (newBuddy.localScale.x * -1, newBuddy.localScale.y, newBuddy.localScale.z); // invert size of different mounts to perfectly loop 
		}

		newBuddy.parent = myTransform.parent;

		// Add a buddy (scene) if 1 , if -1 then no buddy
		if (rightOrLeft > 0) {
			newBuddy.GetComponent<Tiling> ().hasALeftBody = true;
		} 
		else {
			newBuddy.GetComponent<Tiling> ().hasARightBody = true;
		}

	}
}
