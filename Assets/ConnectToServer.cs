using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using Photon.Pun.Demo.Cockpit;
using Unity.VisualScripting;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    public GameObject Camera;
    public Vector2 WorldUnitsInCamera;
    public Vector2 WorldToPixelAmount;
    void Start() {
        Invoke("connect", 4);
    }
    void connect() {
        PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }
    public override void OnJoinedLobby()
    {
        SceneManager.LoadScene("Lobby");
    }
}
