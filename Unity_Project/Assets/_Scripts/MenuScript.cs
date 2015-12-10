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
<<<<<<< HEAD
		Debug.Log ("audio playSound");	
		source.PlayOneShot (menuClickSound);  // Play button click sound
		serverWindow.active = true;
=======
        serverWindow.SetActive(true);
>>>>>>> 81bf7a1905962eecba3bf45b299dc7e1d41be0f4
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
<<<<<<< HEAD
		createRoomWindow.active = false;
=======
        createRoomWindow.SetActive(false);
>>>>>>> 81bf7a1905962eecba3bf45b299dc7e1d41be0f4
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