using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerPrefab;
    public Vector3[] postSpawn;

    public CameraController cameraController;

    private void Start() {
        if(PhotonNetwork.PlayerList.Length == 1){
            cameraController.targets.Add(PhotonNetwork.Instantiate(playerPrefab.name,postSpawn[0],Quaternion.identity).transform);
        }else{
            cameraController.targets.Add(PhotonNetwork.Instantiate(playerPrefab.name,postSpawn[1],Quaternion.identity).transform);
        }
    }
}
