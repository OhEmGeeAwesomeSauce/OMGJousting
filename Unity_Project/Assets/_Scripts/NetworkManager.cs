using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NetworkManager : MonoBehaviour
{

    [SerializeField] Text connectionText;
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] Camera sceneCamera;

    GameObject player;

    void Start()
    {

        PhotonNetwork.logLevel = PhotonLogLevel.Full;
        PhotonNetwork.ConnectUsingSettings("0.1");

    }

    void Update()
    {
        connectionText.text = PhotonNetwork.connectionStateDetailed.ToString()  + " " + PhotonNetwork.countOfPlayers;
    }

    void OnJoinedLobby()
    {
        RoomOptions ro = new RoomOptions() { isVisible = true, maxPlayers = 2 };
        PhotonNetwork.JoinOrCreateRoom("OMG", ro, TypedLobby.Default);
    }

    void OnJoinedRoom()
    {
        StartSpawnProcess(0f);
    }

    void StartSpawnProcess(float respawnTime)
    {
        sceneCamera.enabled = true;
        StartCoroutine("SpawnPlayer", respawnTime);
    }

    IEnumerator SpawnPlayer(float respawnTime)
    {
        yield return new WaitForSeconds(respawnTime);

        int index = Random.Range(0, spawnPoints.Length);
        if(PhotonNetwork.countOfPlayers == 1)
        {
            index = 0;
            player = PhotonNetwork.Instantiate("Player_1_Obj",
                                    spawnPoints[index].position,
                                    spawnPoints[index].rotation,
                                    0);
        }
        else
        {
            index = 1;
            player = PhotonNetwork.Instantiate("Player_2_Obj",
                                    spawnPoints[index].position,
                                    spawnPoints[index].rotation,
                                    0);
        }

        //		player.GetComponent<PlayerNetworkMover> ().RespawnMe += StartSpawnProcess;
        sceneCamera.enabled = false;
    }
}