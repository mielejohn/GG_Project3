using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static Player[] players;
    static bool gameStarted = false;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		while (gameStarted)
        {

        }
	}

    public static void setPlayers(int amountOfPlayers)
    {
        players = new Player[amountOfPlayers];
        ControllerSyncMenu.spawnTesters();
    }

    public static void startGame()
    {
        gameStarted = true;
    }
}