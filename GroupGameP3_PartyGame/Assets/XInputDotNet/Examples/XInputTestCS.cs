using UnityEngine;
using XInputDotNetPure; // Required in C#

public class XInputTestCS : MonoBehaviour
{
    bool playerIndexSet = false;
	public PlayerIndex playerIndex = PlayerIndex.One;
	GamePadState state;
    GamePadState prevState;
    // Use this for initialization
    void Start()
    {
		playerIndex = PlayerIndex.One;
    }

    void FixedUpdate()
    {
        // SetVibration should be sent in a slower rate.
        // Set vibration according to triggers
		playerIndex = PlayerIndex.One;
        GamePad.SetVibration(playerIndex, state.Triggers.Left, state.Triggers.Right);
    }

    // Update is called once per frame
    void Update()
    {
        // Find a PlayerIndex, for a single player game
        // Will find the first controller that is connected ans use it
        if (!playerIndexSet || !prevState.IsConnected)
        {
            for (int i = 0; i < 4; ++i)
            {
                PlayerIndex testPlayerIndex = (PlayerIndex)i;
                GamePadState testState = GamePad.GetState(testPlayerIndex);
                if (testState.IsConnected)
                {
                    Debug.Log(string.Format("GamePad found {0}", testPlayerIndex));
                    playerIndex = testPlayerIndex;
                    playerIndexSet = true;
                }
            }
        }

        prevState = state;
        state = GamePad.GetState(playerIndex);

        // Detect if a button was pressed this frame
		if (playerIndex == PlayerIndex.One && prevState.Buttons.A == ButtonState.Released && state.Buttons.A == ButtonState.Pressed)
        {
			transform.localPosition += new Vector3 (state.ThumbSticks.Left.X * 25.0f * Time.deltaTime, state.ThumbSticks.Left.Y * 25.0f * Time.deltaTime, -5.0f);
            GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value, 1.0f);
        }
        // Detect if a button was released this frame
		if (playerIndex == PlayerIndex.One && prevState.Buttons.A == ButtonState.Pressed && state.Buttons.A == ButtonState.Released)
        {
			transform.localPosition = new Vector3 (this.gameObject.transform.position.x, this.gameObject.transform.position.y, 0.0f);
            GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 255.0f, 1.0f);
        }


		if (playerIndex == PlayerIndex.One && prevState.Buttons.LeftShoulder == ButtonState.Released && state.Buttons.LeftShoulder == ButtonState.Pressed)
		{
			GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value, 1.0f);
		}
	
		if (playerIndex == PlayerIndex.One && prevState.Buttons.LeftShoulder == ButtonState.Pressed && state.Buttons.LeftShoulder == ButtonState.Released)
		{
			GetComponent<Renderer>().material.color = new Color(255.0f, 1.0f, 1.0f, 1.0f);
		}
        // Make the current object turn

		if (playerIndex == PlayerIndex.One) {
			transform.localPosition += new Vector3 (state.ThumbSticks.Left.X * 25.0f * Time.deltaTime, state.ThumbSticks.Left.Y * 25.0f * Time.deltaTime, 0.0f);
			transform.localRotation *= Quaternion.Euler (0.0f, 0.0f, state.ThumbSticks.Right.X * 75.0f * Time.deltaTime);
		}
    }

	/*void OnTriggerEnter2D(Collider2D other){
		Debug.Log ("Colliding with something");
		if (other.tag == "Obstacle" && playerIndex == PlayerIndex.One && prevState.Buttons.A == ButtonState.Released && state.Buttons.A == ButtonState.Pressed) {
			Debug.Log ("Colliding with box");
			transform.localPosition += new Vector3 (0.0f, 0.0f, 0.0f);
		}
	}*/

    void OnGUI()
    {
        string text = "Use left stick to turn the cube, hold A to change color\n";
        text += string.Format("IsConnected {0} Packet #{1}\n", state.IsConnected, state.PacketNumber);
        text += string.Format("\tTriggers {0} {1}\n", state.Triggers.Left, state.Triggers.Right);
        text += string.Format("\tD-Pad {0} {1} {2} {3}\n", state.DPad.Up, state.DPad.Right, state.DPad.Down, state.DPad.Left);
        text += string.Format("\tButtons Start {0} Back {1} Guide {2}\n", state.Buttons.Start, state.Buttons.Back, state.Buttons.Guide);
        text += string.Format("\tButtons LeftStick {0} RightStick {1} LeftShoulder {2} RightShoulder {3}\n", state.Buttons.LeftStick, state.Buttons.RightStick, state.Buttons.LeftShoulder, state.Buttons.RightShoulder);
        text += string.Format("\tButtons A {0} B {1} X {2} Y {3}\n", state.Buttons.A, state.Buttons.B, state.Buttons.X, state.Buttons.Y);
        text += string.Format("\tSticks Left {0} {1} Right {2} {3}\n", state.ThumbSticks.Left.X, state.ThumbSticks.Left.Y, state.ThumbSticks.Right.X, state.ThumbSticks.Right.Y);
        GUI.Label(new Rect(0, 0, Screen.width, Screen.height), text);

		//Debug.Log (Input.GetJoystickNames());
    }
}
