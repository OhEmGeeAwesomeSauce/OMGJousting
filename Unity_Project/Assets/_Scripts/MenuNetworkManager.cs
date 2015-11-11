using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class MenuNetworkManager : MonoBehaviour
{
    [SerializeField] Text connectionText;

    [SerializeField] GameObject serverWindow;
    [SerializeField] GameObject createWindow;

    [SerializeField] InputField username;
    [SerializeField] InputField roomName;
    [SerializeField] InputField messageWindow;

    Queue<string> messages;
    const int messageCount = 6;
    PhotonView photonView;


    void Start()
    {
        photonView = GetComponent<PhotonView>();
        messages = new Queue<string>(messageCount);

        PhotonNetwork.logLevel = PhotonLogLevel.Full;
        PhotonNetwork.ConnectUsingSettings("1.0");
        StartCoroutine("UpdateConnectionString");
    }

    IEnumerator UpdateConnectionString()
    {
        while (true)
        {
            connectionText.text = PhotonNetwork.connectionStateDetailed.ToString();
            yield return null;
        }
    }

    void OnJoinedLobby()
    {
        
    }

    void OnReceivedRoomListUpdate()
    {
        RoomInfo[] rooms = PhotonNetwork.GetRoomList();
    }

    public void JoinRandom()
    {
        PhotonNetwork.player.name = username.text;
        PhotonNetwork.JoinRandomRoom(null, 2);
    }

    void OnPhotonRandomJoinFailed()
    {
        PhotonNetwork.player.name = username.text;
        RoomOptions roomOptions = new RoomOptions() { isVisible = true, maxPlayers = 2 };
        PhotonNetwork.CreateRoom(username.text + Random.value, roomOptions, TypedLobby.Default);
    }

    public void JoinRoom()
    {
        PhotonNetwork.player.name = username.text;
        RoomOptions roomOptions = new RoomOptions() { isVisible = false, maxPlayers = 2 };
        PhotonNetwork.JoinOrCreateRoom(roomName.text, roomOptions, TypedLobby.Default);
    }

    void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel(1);
    }

    void AddMessage(string message)
    {
        photonView.RPC("AddMessage_RPC", PhotonTargets.All, message);
    }

    [PunRPC]
    void AddMessage_RPC(string message)
    {
        messages.Enqueue(message);
        if (messages.Count > messageCount)
            messages.Dequeue();

        messageWindow.text = "";
        foreach (string m in messages)
            messageWindow.text += m + "\n";
    }
}