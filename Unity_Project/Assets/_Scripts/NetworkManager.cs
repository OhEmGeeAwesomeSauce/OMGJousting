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
        connectionText.text = PhotonNetwork.connectionStateDetailed.ToString() + " " + PhotonNetwork.countOfPlayers;
    }

    void OnJoinedLobby()
    {
        RoomOptions ro = new RoomOptions() { isVisible = true, maxPlayers = 2 };
        PhotonNetwork.JoinOrCreateRoom("OMG", ro, TypedLobby.Default);
    }

    void OnJoinedRoom()
    {
        sceneCamera.enabled = true;
        if(PhotonNetwork.countOfPlayers == 2)
        {
            SpawnPlayer(1);
        }
    }

    void SpawnPlayer(int index)
    {

        if (index == 0)
        {
            player = PhotonNetwork.Instantiate("Player_1_Obj",
                                    spawnPoints[index].position,
                                    spawnPoints[index].rotation,
                                    0);
        }
        else
        {
            player = PhotonNetwork.Instantiate("Player_2_Obj",
                                    spawnPoints[index].position,
                                    spawnPoints[index].rotation,
                                    0);
        }

        //		player.GetComponent<PlayerNetworkMover> ().RespawnMe += StartSpawnProcess;
        sceneCamera.enabled = false;
    }

    void OnPhotonPlayerConnected(PhotonPlayer newPlayer)
    {
        SpawnPlayer(0);
    }
}