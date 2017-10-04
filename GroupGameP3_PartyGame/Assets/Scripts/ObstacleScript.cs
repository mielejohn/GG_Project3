using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour {

	void Start () {
		
	}

	void Update () {
		//Debug.Log ("Script is working");
	}

	void OnTriggerEnter2D(Collider2D other){
		Debug.Log ("Trigger enter has happened");
		if (other.tag == "PlayerOne" || other.tag == "PlayerTwo" || other.tag == "PlayerThree" || other.tag == "PlayerFour") {
			Debug.Log ("Colliding with a player");
		}
	}
}
