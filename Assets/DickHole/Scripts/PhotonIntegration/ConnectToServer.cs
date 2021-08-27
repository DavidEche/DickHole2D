using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;


public class ConnectToServer : MonoBehaviourPunCallbacks, IMatchmakingCallbacks
{

    private byte maxPlayers = 2;
    public void Connect() {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("In Lobby");
        JoinRoom();
    }

    private void JoinRoom(){
        PhotonNetwork.JoinRandomRoom();
    }

    void IMatchmakingCallbacks.OnJoinRandomFailed(short returnCode, string message){
        PhotonNetwork.CreateRoom(null, new RoomOptions(){MaxPlayers = maxPlayers}, null);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("GameplayScene");
    }

}
