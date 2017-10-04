using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class InputLablingtest : MonoBehaviour {

	bool playerIndexSet = false;
	PlayerIndex playerIndex;
	GamePadState state;
	GamePadState prevState;

	void Start () {
		
	}

	void Update () {
		if (!playerIndexSet || !prevState.IsConnected) {
		
		}
	}
}
