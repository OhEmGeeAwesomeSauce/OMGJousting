using UnityEngine;
using System.Collections;

public class GameDone : MonoBehaviour {
    float timer;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if(timer > 5.0)
        {
            Application.LoadLevel("startmenu");
        }
	}
}
