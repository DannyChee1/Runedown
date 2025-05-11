using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Unity.VisualScripting.Antlr3.Runtime.Tree;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject playerPrefab2;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public float minX2;
    public float maxX2;
    public float minY2;
    public float maxY2;
    private void Start() {
        Vector2 randomPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        Vector2 randomPosition2 = new Vector2(Random.Range(minX2, maxX2), Random.Range(minY2, maxY2));
        //PhotonNetwork.Instantiate(playerPrefab.name, randomPosition, Quaternion.identity);
        if(PhotonNetwork.CurrentRoom.PlayerCount == 1) {
            PhotonNetwork.Instantiate(playerPrefab.name, randomPosition, Quaternion.identity);
        }
        else if(PhotonNetwork.CurrentRoom.PlayerCount == 2) {
            PhotonNetwork.Instantiate(playerPrefab2.name, randomPosition2, Quaternion.identity);
        }
    }
    
}
