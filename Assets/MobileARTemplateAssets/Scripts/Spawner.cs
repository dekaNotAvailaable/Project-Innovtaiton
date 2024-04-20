using Photon.Pun;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoints; // Array to hold the spawn points
    void Start()
    {
        // Get the local player's index
        int playerIndex = PhotonNetwork.LocalPlayer.ActorNumber % spawnPoints.Length;
        // Instantiate the player prefab at the corresponding spawn point
        PhotonNetwork.Instantiate("Player", spawnPoints[playerIndex].position, Quaternion.identity);
        // Debug.Log(spawnPoints[playerIndex].position);
    }
}
