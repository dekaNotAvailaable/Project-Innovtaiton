using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
public class RoomManager : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private GameObject quickStartButton;
    [SerializeField]
    private GameObject quickCancelButton;
    [SerializeField]
    private int roomSize;
    void Start()
    {
        Debug.Log("Connecting...");
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();

        PhotonNetwork.AutomaticallySyncScene = true;
        quickStartButton.SetActive(true);
        Debug.Log("Connected to Server");
        PhotonNetwork.JoinLobby();
    }

    public void QuickStart()
    {
        quickStartButton.SetActive(true);
        quickCancelButton.SetActive(true);
        PhotonNetwork.JoinRandomRoom();
        Debug.Log("Quick start");
    }

    void CreateRoom()
    {
        Debug.Log("Creating room now");
        int randomRoomNumber = Random.Range(0, 10000);
        RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = (byte)roomSize };
        PhotonNetwork.CreateRoom("Room" + randomRoomNumber, roomOps);
        Debug.Log(randomRoomNumber);
    }
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Failed to join a room");
        CreateRoom();
    }

    public void QuickCancel()
    {
        PhotonNetwork.LeaveRoom();
        Debug.Log("We have left the room");
    }
    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        PhotonNetwork.JoinOrCreateRoom("test", null, null);
        Debug.Log("We're connected in lobby");
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        Debug.Log("We're connected in a room");
    }
}