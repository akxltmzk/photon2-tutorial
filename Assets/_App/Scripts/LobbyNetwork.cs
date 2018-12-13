using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class LobbyNetwork : MonoBehaviourPunCallbacks 
{
    public static LobbyNetwork Instance;
    public GameObject battleButton;
    public GameObject cancleButton;

    private void Awake()
    {
        Instance = this;
    }
    private void Start ()
	{
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Player has connected to the Photon master server");
        PhotonNetwork.AutomaticallySyncScene = true;
        battleButton.SetActive(true);
    }

    public void OnBattleButtonClicked()
    {
        Debug.Log("Battle Button was clicked");
        battleButton.SetActive(false);
        cancleButton.SetActive(true);
        PhotonNetwork.JoinRandomRoom();
    }

    public void OnCancleButtonClicked()
    {
        Debug.Log("Cancle Button was clicked");
        battleButton.SetActive(true);
        cancleButton.SetActive(false);
        PhotonNetwork.LeaveRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Tried to join a random game but failed. There must be no open games available");
        CreateRoom();
    }

    void CreateRoom()
    {
        Debug.Log("Trying to create a new Room");
        int randomRoomName = Random.Range(0, 1000);
        RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = (byte)MultiplayerSetting.instance.maxPlayers };
        PhotonNetwork.CreateRoom("Room" + randomRoomName, roomOps);
    }



    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        CreateRoom();
    }
}
