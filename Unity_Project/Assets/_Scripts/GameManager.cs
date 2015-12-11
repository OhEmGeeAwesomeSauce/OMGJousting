using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    private static int playerScore;

	//void Start () {
    void Awake() {
        //Makes sure there is only one instance
        if(instance == null)
        {
            instance = this;
        }
        else if( instance != this)
        {
            Destroy(gameObject);
        }
        //Allows the gameobject to remain alive through scenes
        DontDestroyOnLoad(gameObject);
        playerScore = 0;
    }
	
	void InitGame()
    {

    }

	void Update () {
	    
	}

    public void updateScore(int score)
    {
        playerScore  = score;
    }

    public int getScore()
    {
        return playerScore;
    }
}
