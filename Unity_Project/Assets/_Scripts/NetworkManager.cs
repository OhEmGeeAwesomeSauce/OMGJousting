using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NetworkManager : MonoBehaviour
{

    [SerializeField] Text connectionText;
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] Camera sceneCamera;

    GameObject player;

    private int pIndex;
    private bool spawned = false;

    void Start()
    {
        PhotonNetwork.logLevel = PhotonLogLevel.Full;
        PhotonNetwork.ConnectUsingSettings("0.1");
        pIndex = PhotonNetwork.playerList.Length;
    }

    void Update()
    {
 //       connectionText.text = PhotonNetwork.connectionStateDetailed.ToString() + " " + PhotonNetwork.playerList.Length + " " + pIndex;
        if (!spawned)
        {
            if (PhotonNetwork.playerList.Length == 2)
            {
                SpawnPlayer();
                spawned = true;
            }
        }
    }


    void OnJoinedRoom()
    {
        sceneCamera.enabled = true;
        if (PhotonNetwork.playerList.Length == 2)
        {
            SpawnPlayer();
        }
    }

    void SpawnPlayer()
    {

        //       player = PhotonNetwork.Instantiate("Player_"+ pIndex +"_Obj",
        player = PhotonNetwork.Instantiate("Player" + pIndex,
            spawnPoints[pIndex-1].position,
            spawnPoints[pIndex-1].rotation,
            0);

        if (pIndex == 1)
        {
            player.GetComponent<Player1NetworkMover>().enabled = true;
        }
        else
        {
            player.GetComponent<Player2NetworkMover>().enabled = true;
        }
        sceneCamera.enabled = false;
    }

    void OnPhotonPlayerConnected(PhotonPlayer newPlayer)
    {
    }
}