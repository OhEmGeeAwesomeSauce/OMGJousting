﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuScript: MonoBehaviour
{

    public Canvas quitMenu; //not used yet
    public Button startText;
    public Button exitText;
    public Button joinRandom;
    public Button createRoom;
    public Button joinAndCreateRoom;

    public GameObject serverWindow;
    public GameObject createRoomWindow;

    // Use this for initialization
    void Start()
    {
        startText = startText.GetComponent<Button>();
        exitText = exitText.GetComponent<Button>();
        joinRandom = joinRandom.GetComponent<Button>();
        createRoom = createRoom.GetComponent<Button>();
        joinAndCreateRoom = joinAndCreateRoom.GetComponent<Button>();
    }

    public void StartGame()
    {
        serverWindow.SetActive(true);
    }

    public void JoinRandom()
    {
        serverWindow.SetActive(false);
    }

    public void CreatePrivate()
    {
        serverWindow.SetActive(false);
        createRoomWindow.SetActive(true);
    }

    public void StartRoom()
    {
        createRoomWindow.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }



    // Update is called once per frame
    void Update()
    {

    }
}