using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float speedX;
	public float speedY;
	public float speedZ;

	void Update () {
		float vertical = Input.GetAxis ("Vertical");
		float horizontal = Input.GetAxis ("Horizontal");


		if (Input.GetKey ("up") || Input.GetKey("down")) {
			if (Input.GetKey (KeyCode.LeftAlt)) {
				MoveUpDown(vertical);
			} else {
				MoveForwardBackward (vertical);
			}
		}

		if (Input.GetKey ("right") || Input.GetKey ("left")) {
			MoveRightLeft(horizontal);
		}

	}

	void MoveUpDown(float vertical){
		transform.Translate (0, vertical * speedY, 0); 
	}

	void MoveForwardBackward(float vertical){
		transform.Translate (0, 0, vertical * speedZ); 
	}

	void MoveRightLeft(float horizontal){
		transform.Translate (horizontal * speedX, 0, 0);
	}

}
