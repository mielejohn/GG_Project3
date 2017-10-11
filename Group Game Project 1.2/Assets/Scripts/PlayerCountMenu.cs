using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerCountMenu : MonoBehaviour
{
    Button twoPlayersButton;
    Button threePlayersButton;
    Button fourPlayersButton;

    Text instructionText;
    Text actionButtonText;

	// Use this for initialization
	void Start ()
    {
        twoPlayersButton = GameObject.Find("TwoPlayersButton").GetComponentInChildren<Button>();
        threePlayersButton = GameObject.Find("ThreePlayersButton").GetComponentInChildren<Button>();
        fourPlayersButton = GameObject.Find("FourPlayersButton").GetComponentInChildren<Button>();

        instructionText = GameObject.Find("SelectPlayersText").GetComponentInChildren<Text>();
        actionButtonText = GameObject.Find("ActionButtonTextPCM").GetComponentInChildren<Text>();

        instructionText.text = "Select Players:";
        actionButtonText.text = "A - Advance | B - Back";

        twoPlayersButton.onClick.AddListener(onTwoPlayers);
        threePlayersButton.onClick.AddListener(onThreePlayers);
        fourPlayersButton.onClick.AddListener(onFourPlayers);
    }

    void onTwoPlayers()
    {
        GameManager.setPlayers(2);
        Debug.Log("Two Players Pressed!");
        UIManager.changeMenu(Menu.ControllerSync);
    }

    void onThreePlayers()
    {
        GameManager.setPlayers(3);
        Debug.Log("Three Players Pressed!");
        UIManager.changeMenu(Menu.ControllerSync);
    }

    void onFourPlayers()
    {
        GameManager.setPlayers(4);
        Debug.Log("Four Players Pressed!");
        UIManager.changeMenu(Menu.ControllerSync);
    }
}
