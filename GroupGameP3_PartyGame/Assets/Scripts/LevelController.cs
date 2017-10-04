using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class LevelController : MonoBehaviour {

	//public PlayerIndex playerOneIndex;
	public PlayerIndex playerTwoIndex = PlayerIndex.Two;
	GamePadState state;
	GamePadState prevState;

	public GameObject PlayerOne;
	public GameObject PlayerTwo;

	//public GameObject PlayerOne;
	//public GameObject PlayerOne;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (prevState.Buttons.A == ButtonState.Released && state.Buttons.A == ButtonState.Pressed)
		{
			//PlayerOne.gameObject.GetComponent<XInputTestCS> ().playerIndex = PlayerIndex.One;
			//playerOneIndex = One;

		}
		// Detect if a button was released this frame
		if (prevState.Buttons.B == ButtonState.Pressed && state.Buttons.B == ButtonState.Released)
		{
			//PlayerOne.gameObject.GetComponent<XInputTestCS> ().playerIndex = PlayerIndex.Two;
			//playerOneIndex = PlayerIndex.Two;
		}
	}
}
