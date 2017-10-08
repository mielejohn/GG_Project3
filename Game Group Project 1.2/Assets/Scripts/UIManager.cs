using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public enum Menu
{
    Main,
    PlayerCount
    //ControllerSync
}

public class UIManager : MonoBehaviour
{
    Canvas[] Menus;
    Menu currentMenuEnum;

    void Awake()
    {
        Menus = new Canvas[System.Enum.GetNames(typeof(Menu)).Length];

        for (int i = 0; i < Menus.Length; i++)
            Menus[i] = Instantiate(Resources.Load<Canvas>("MenuCanvases" + Path.DirectorySeparatorChar + System.Enum.GetName(typeof(Menu), i)), this.transform);

        foreach (Canvas c in Menus)
            Debug.Log(c.ToString());

        currentMenuEnum = Menu.Main;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentMenuEnum > 0)
            if (Input.GetButtonDown("Cancel"))
                changeMenu(currentMenuEnum - 1);
    }

    public void changeMenu(Menu menu)
    {
        Debug.Log("Switching to menu: " + menu);
        Menus[(int)currentMenuEnum].enabled = false;
        currentMenuEnum = menu;
        Menus[(int)currentMenuEnum].enabled = true;
    }
}