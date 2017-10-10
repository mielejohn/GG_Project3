using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XInputDotNetPure;

public class LevelController : MonoBehaviour {

	//public PlayerIndex playerOneIndex;
	public PlayerIndex playerTwoIndex = PlayerIndex.Two;
	GamePadState state;
	GamePadState prevState;

	public GameObject PlayerOne;
	public GameObject PlayerTwo;

	public GameObject Wall;
	public GameObject WallSpawn;
	//public GameObject WallEnd;

	public Text Clock;

	public float time=	4.0f;
	//public float AnimSpeed = 0.0f;
	public int timer = 30;

	public int PlayerOnePlace = 0;
	public int PlayerTwoPlace = 0;
	public int PlayerThreePlace = 0;
	public int PlayerFourPlace = 0;

	void Start () {
		StartCoroutine (SpawnWall ());
		StartCoroutine (Timer ());
	}
	
	// Update is called once per frame
	void Update () {
		//timer -= 1;
		Clock.text = ""+ timer;

		if (timer == 0) {
			if (GameObject.FindGameObjectWithTag ("PlayerOne").activeSelf == true) {
				PlayerOnePlace = 1;
			}
			if (GameObject.FindGameObjectWithTag ("PlayerTwo").activeSelf == true) {
				PlayerTwoPlace = 1;
			}
			if (GameObject.FindGameObjectWithTag ("PlayerThree").activeSelf == true) {
				PlayerThreePlace = 1;
			}
			if (GameObject.FindGameObjectWithTag ("PlayerFour").activeSelf == true) {
				PlayerFourPlace = 1;
			}
		}
	}

	public IEnumerator SpawnWall(){
		yield return new WaitForSeconds (time);
		GameObject WallI = Instantiate (Wall);
		WallI.gameObject.transform.position = WallSpawn.transform.position;
		WallI.gameObject.GetComponent<Animator> ().Play ("WallMove", -1, 0.0f);
		yield return new WaitForSeconds (2.35f);
		TimeDecrease ();
		Destroy (WallI);
		StartCoroutine (SpawnWall ());
	}

	public void TimeDecrease(){
		if (time >= 0.5) {
			time -= 0.75f;
			//AnimSpeed += 0.39f;
		}
	}

	public IEnumerator Timer(){
		yield return new WaitForSeconds (1.0f);
		if (timer > 0) {
			timer -= 1;
			StartCoroutine (Timer ());
		}
	}
}