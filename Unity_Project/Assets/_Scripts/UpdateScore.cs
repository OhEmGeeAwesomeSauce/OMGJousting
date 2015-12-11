﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpdateScore : MonoBehaviour {
    private Text text;
    private int score;

	void Awake ()
    {
        text = GetComponent<Text>();
        score = 0;
    }
	

	void Update () {
        score = GameManager.instance.getScore();
        text.text = "Score:" + score;
	}
}