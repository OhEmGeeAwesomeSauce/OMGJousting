using UnityEngine;
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

	// Audio Stuff
	private AudioSource source;
	public  AudioClip   menuClickSound;   

    // Use this for initialization
    void Start()
    {
		source = GetComponent<AudioSource>();
		startText = startText.GetComponent<Button>();
        exitText = exitText.GetComponent<Button>();
        joinRandom = joinRandom.GetComponent<Button>();
        createRoom = createRoom.GetComponent<Button>();
        joinAndCreateRoom = joinAndCreateRoom.GetComponent<Button>();
    }

    public void StartGame()
    {
		Debug.Log ("audio playSound");	
		source.PlayOneShot (menuClickSound);  // Play button click sound
		serverWindow.active = true;
    }

    public void JoinRandom()
    {
        serverWindow.active = false;
    }

    public void CreatePrivate()
    {
        serverWindow.active = false;
        createRoomWindow.active = true;
    }

    public void StartRoom()
    {
		createRoomWindow.active = false;
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