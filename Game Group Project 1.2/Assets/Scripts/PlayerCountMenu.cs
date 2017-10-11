using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerCountMenu : MonoBehaviour
{
    UIManager UIManager;
    GameManager gameManager;

    Button twoPlayersButton;
    Button threePlayersButton;
    Button fourPlayersButton;

    Text instructionText;
    Text actionButtonText;

	// Use this for initialization
	void Start ()
    {
        UIManager = GetComponentInParent<UIManager>();
        gameManager = GetComponentInParent<GameManager>();

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
        Debug.Log("Two Players Pressed!");
    }

    void onThreePlayers()
    {
        Debug.Log("Three Players Pressed!");
    }

    void onFourPlayers()
    {
        Debug.Log("Four Players Pressed!");
    }
}
