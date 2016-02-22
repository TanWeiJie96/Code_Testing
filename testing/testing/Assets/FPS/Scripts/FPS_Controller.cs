using UnityEngine;
using System.Collections;

public class FPS_Controller : MonoBehaviour {

	//----Movement----//
	public float forwardSpeed; 		 // Move forward + backward
	public float sideSpeed;	  		 // Move left + right
	public Vector3 speed;	   		 // Moving Vector
	public float movementSpeed = 3;  // Moving speed 

	//----Rotation----//
	public float rotLeftRight;				// Rotate Left + Right
	public float rotUpDown;					// Rotate Up + Down
	public float mouseSensitivity = 3;		// Mouse Sentivity
	public float lookUpDownRange = 60.0f;	// Limit how much player can look up and down
	public float verticalRotation = 0;

	// Use this for initialization
	void Start () {
		Cursor.visible = false;

	}
	
	// Update is called once per frame
	void Update () {

		//Rotation
		rotLeftRight = Input.GetAxis ("Mouse X") * mouseSensitivity; //Yaw
		transform.Rotate(0, rotLeftRight, 0);

		verticalRotation -= Input.GetAxis ("Mouse Y") * mouseSensitivity; // Pitch
		verticalRotation = Mathf.Clamp(verticalRotation, -lookUpDownRange, lookUpDownRange);
		Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

		// Movement
		forwardSpeed = Input.GetAxis ("Vertical") * movementSpeed; // Retrieve Vertical Axis
		sideSpeed = Input.GetAxis ("Horizontal") * movementSpeed;  // Retrieve Horizontal Axis

		speed = new Vector3(sideSpeed, 0, forwardSpeed); // Using World Coord

		speed = transform.rotation * speed; // speed adjust by rotation

		CharacterController cc = GetComponent<CharacterController>();	// Retrieve CharacterController

		cc.SimpleMove(speed);
	}
}
