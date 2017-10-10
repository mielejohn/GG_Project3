using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class PlayerThreeScript : MonoBehaviour {
	
		bool playerIndexSet = false;
		public PlayerIndex playerIndex = PlayerIndex.Three;
		GamePadState state;
		GamePadState prevState;
		public float speed = 4.0f;
		public GameObject Wall;
		public GameObject GC;
		public SpriteRenderer SR;

		//public int timeAlive;
		// Use this for initialization
		void Start()
		{
			playerIndex = PlayerIndex.Three;
			//Wall = GameObject.FindGameObjectWithTag ("Obstacle");
		}

		void FixedUpdate()
		{
			// SetVibration should be sent in a slower rate.
			// Set vibration according to triggers
			playerIndex = PlayerIndex.Three;
			// GamePad.SetVibration(playerIndex, state.Triggers.Left, state.Triggers.Right);
			Wall = GameObject.FindGameObjectWithTag ("Obstacle");
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
						//  Debug.Log(string.Format("GamePad found {0}", testPlayerIndex));
						playerIndex = testPlayerIndex;
						playerIndexSet = true;
					}
				}
			}

			prevState = state;
			state = GamePad.GetState(playerIndex);

			// Detect if a button was pressed this frame
			if (playerIndex == PlayerIndex.Three && prevState.Buttons.A == ButtonState.Released && state.Buttons.A == ButtonState.Pressed)
			{
				transform.localPosition += new Vector3 (state.ThumbSticks.Left.X * 25.0f * Time.deltaTime, state.ThumbSticks.Left.Y * 25.0f * Time.deltaTime, -5.0f);
				SR.color = Color.green;
				// GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value, 1.0f);
			}
			// Detect if a button was released this frame
			if (playerIndex == PlayerIndex.Three && prevState.Buttons.A == ButtonState.Pressed && state.Buttons.A == ButtonState.Released)
			{
				transform.localPosition = new Vector3 (this.gameObject.transform.position.x, this.gameObject.transform.position.y, -1.0f);
				SR.color = Color.yellow;
				// GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 255.0f, 1.0f);
			}

			if (playerIndex == PlayerIndex.Three) {
				transform.localPosition += new Vector3 (state.ThumbSticks.Left.X * speed * Time.deltaTime, state.ThumbSticks.Left.Y * speed * Time.deltaTime, 0.0f);
				//transform.localRotation *= Quaternion.Euler (0.0f, 0.0f, state.ThumbSticks.Right.X * 75.0f * Time.deltaTime);
			}
		}

		void OnTriggerEnter2D(Collider2D other){
			if (other.tag == "Obstacle") {
				if (this.gameObject.transform.position.z >= Wall.gameObject.transform.position.z) {
					this.gameObject.SetActive (false);
					//timeAlive =	GC.gameObject.GetComponent<LevelController> ().timer;
				}
				Debug.Log ("In collider");
			}
		}	 
	}