using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XInputDotNetPure;

public class LevelController : MonoBehaviour {

	public PlayerIndex playerTwoIndex = PlayerIndex.Two;
	GamePadState state;
	GamePadState prevState;

	public GameObject Wall;
	public GameObject WallSpawn;
	public bool GameOver = false;
	public GameObject Instructions;
	public int AmountofPlayers;
	public GameObject GameStartFading;
	public GameObject GameFinishedText;

	public Text Clock;
	public int PlayerDeath = 0;

	public float time=	4.0f;
	public int timer = 30;

	public GameObject PlayerOne;
	public int PlayerOnePlace = 0;

	public GameObject PlayerTwo;
	public int PlayerTwoPlace = 0;

	public GameObject PlayerThree;
	public int PlayerThreePlace = 0;

	public GameObject PlayerFour;
	public int PlayerFourPlace = 0;

	public bool playing = false;

	void Start () {
		StartCoroutine (GameStarted ());
	}

	void Update () {
		Clock.text = ""+ timer;

		if (timer <= 0 || PlayerDeath  == AmountofPlayers -1) {
			StartCoroutine (GameFinished());
			GameOver = true;
			if (PlayerOne.activeSelf == true) {
				PlayerOnePlace = 1;
			}
			if (PlayerTwo.activeSelf == true) {
				PlayerTwoPlace = 1;
			}
			if (PlayerThree.activeSelf == true) {
				PlayerThreePlace = 1;
			}
			if (PlayerFour.activeSelf == true) {
				PlayerFourPlace = 1;
			}
		}

		if(playing == false){
			if (PlayerOne.gameObject.GetComponent<PlayerOneScript>().playerIndex == PlayerIndex.One && PlayerOne.gameObject.GetComponent<PlayerOneScript>().prevState.Buttons.A == ButtonState.Released && PlayerOne.gameObject.GetComponent<PlayerOneScript>().state.Buttons.A == ButtonState.Pressed) {
				Instructions.SetActive (false);
				StartCoroutine (SpawnWall ());
				StartCoroutine (Timer ());
				playing = true;
			}
		}
	}

	public IEnumerator SpawnWall(){
		if (GameOver == false) {
			yield return new WaitForSeconds (time);
			GameObject WallI = Instantiate (Wall);
			WallI.gameObject.transform.position = WallSpawn.transform.position;
			WallI.gameObject.GetComponent<Animator> ().Play ("WallMove", -1, 0.0f);
			yield return new WaitForSeconds (2.35f);
			TimeDecrease ();
			Destroy (WallI);
			StartCoroutine (SpawnWall ());
		}
	}

	public void TimeDecrease(){
		if (time >= 0.5) {
			time -= 0.75f;
		}
	}

	public IEnumerator Timer(){
			yield return new WaitForSeconds (1.0f);
		if (GameOver == false) {
			if (timer > 0) {
				timer -= 1;
				StartCoroutine (Timer ());
			} else {
				GameOver = true;
			}
		}
	}
	public IEnumerator GameStarted(){
		GameStartFading.gameObject.GetComponent<Animator> ().Play ("GameStart_StartFade", 0, 1.0f);
		yield return new WaitForSeconds (1.9f);
		GameStartFading.gameObject.SetActive (false);
	}
	public IEnumerator GameFinished(){
		GameFinishedText.gameObject.SetActive (true);
		yield return new WaitForSeconds (1.9f);
		GameFinishedText.gameObject.GetComponent<Animator> ().Play ("GameFinished_EndAnim", 0, 1.0f);
	}
}