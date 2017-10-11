using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    Button startButton;
    Button quitButton;

    Text gameTitleText;
    Text actionButtonText;

    // Use this for initialization
    void Start()
    {
        startButton = GameObject.Find("StartButton").GetComponentInChildren<Button>();
        quitButton = GameObject.Find("QuitButton").GetComponentInChildren<Button>();

        gameTitleText = GameObject.Find("GameTitleText").GetComponentInChildren<Text>();
        actionButtonText = GameObject.Find("ActionButtonTextMM").GetComponentInChildren<Text>();

        gameTitleText.text = "Group Game Project 1.2.0";
        actionButtonText.text = "Press A to continue";
        startButton.GetComponentInChildren<Text>().text = "Start Game";
        quitButton.GetComponentInChildren<Text>().text = "Quit";

        startButton.onClick.AddListener(onStart);
        quitButton.onClick.AddListener(onQuit);
    }

    void onStart()
    {
        Debug.Log("Start Pressed!");
        UIManager.changeMenu(Menu.PlayerCount);
    }

    void onQuit()
    {
        Debug.Log("Application Quitting");
        Application.Quit();
    }
}