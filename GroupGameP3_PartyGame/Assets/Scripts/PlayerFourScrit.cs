using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class PlayerFourScrit : MonoBehaviour {

	bool playerIndexSet = false;
	public PlayerIndex playerIndex = PlayerIndex.Four;
	GamePadState state;
	GamePadState prevState;
	public float speed = 8.0f;
	public GameObject Wall;
	public GameObject GC;
	public SpriteRenderer SR;
	public bool CanJump = true;
	void Start()
	{
		playerIndex = PlayerIndex.Four;
	}

	void FixedUpdate()
	{
		playerIndex = PlayerIndex.Four;
		Wall = GameObject.FindGameObjectWithTag ("Obstacle");
	}

	void Update()
	{
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

		if (playerIndex == PlayerIndex.Four && prevState.Buttons.A == ButtonState.Released && state.Buttons.A == ButtonState.Pressed && CanJump == true)
		{
			StartCoroutine(JumpAction());
		}

		if (playerIndex == PlayerIndex.Four) {
			transform.localPosition += new Vector3 (state.ThumbSticks.Left.X * speed * Time.deltaTime, state.ThumbSticks.Left.Y * speed * Time.deltaTime, 0.0f);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Obstacle") {
			if (this.gameObject.transform.position.z >= Wall.gameObject.transform.position.z) {
				GC.gameObject.GetComponent<LevelController> ().PlayerDeath++;
				this.gameObject.SetActive (false);
			}
			Debug.Log ("In collider");
		}
	} 

	public IEnumerator JumpAction(){
		SR.color = Color.black;
		transform.localPosition += new Vector3 (state.ThumbSticks.Left.X * 25.0f * Time.deltaTime, state.ThumbSticks.Left.Y * 25.0f * Time.deltaTime, -5.0f);
		yield return new WaitForSeconds (0.3f);
		CanJump = false;
		transform.localPosition = new Vector3 (this.gameObject.transform.position.x, this.gameObject.transform.position.y, -1.0f);
		SR.color = Color.green;
		StartCoroutine (JumpBuffer ());
	}

	public IEnumerator JumpBuffer(){
		CanJump = false;
		yield return new WaitForSeconds (1.3f);
		CanJump = true;
	}   
}