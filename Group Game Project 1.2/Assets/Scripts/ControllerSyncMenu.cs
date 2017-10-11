using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ControllerSyncMenu : MonoBehaviour
{
    Text instructionText;
    Text actionButtonText;

    static GameObject[] testers;

    bool synced = false;

    // Use this for initialization
    void Start ()
    {
        testers = new GameObject[4];

        for (int i = 0; i < testers.Length; i++)
            testers[i] = GameObject.Find("Tester" + i);

        foreach (GameObject g in testers)
            Debug.Log(g.ToString());

        instructionText = GameObject.Find("SyncControllersText").GetComponentInChildren<Text>();
        actionButtonText = GameObject.Find("ActionButtonTextCSM").GetComponentInChildren<Text>();

        instructionText.text = "Press A to sync controller to a character:";
        actionButtonText.text = "A - Sync | B - Back";
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonDown("Cancel"))
            for (int i = 0; i < GameManager.players.Length; i++)
                testers[i].GetComponent<SpriteRenderer>().enabled = false;

        if (synced)
            if (Input.GetButtonDown("Submit"))
                GameManager.startGame();
    }

    public static void spawnTesters()
    {
        for (int i = 0; i < GameManager.players.Length; i++)
            testers[i].GetComponent<SpriteRenderer>().enabled = true;
    }
}