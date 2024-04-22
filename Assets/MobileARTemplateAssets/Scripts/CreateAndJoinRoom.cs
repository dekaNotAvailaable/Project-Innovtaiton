using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;

public class CreateAndJoinRoom : MonoBehaviourPunCallbacks
{
    public TMP_InputField createInput;
    public TMP_Text createInputPlaceHolder;
    public TMP_Text joinInputPlaceHolder;
    public TMP_InputField joinInput;
    private void Start()
    {
        ConnectToPhoton();
    }

    void ConnectToPhoton()
    {
        if (!PhotonNetwork.IsConnected)
        {
            PhotonNetwork.ConnectUsingSettings();
        }
    }
    public void Disconnect()
    {
        SoundEffects.Instance.ButtonSoundPlay();
        if (PhotonNetwork.InRoom)
        {
            PhotonNetwork.LeaveRoom();
        }
        else if (PhotonNetwork.InLobby)
        {
            PhotonNetwork.LeaveLobby();
        }
        PhotonNetwork.Disconnect();
    }
    public void CreateRoom()
    {
        SoundEffects.Instance.ButtonSoundPlay();
        if (!PhotonNetwork.IsConnected)
        {
            Debug.LogWarning("Not connected to Photon Master Server. Waiting to establish connection.");
            return;
        }
        if (string.IsNullOrEmpty(createInput.text))
        {
            createInputPlaceHolder.text = "Room name can't be empty";
        }
        else
        {
            PhotonNetwork.CreateRoom(createInput.text);
        }
    }

    public void JoinRoom()
    {
        SoundEffects.Instance.ButtonSoundPlay();
        if (!PhotonNetwork.IsConnected)
        {
            Debug.LogWarning("Not connected to Photon Master Server. Waiting to establish connection.");
            return;
        }
        if (string.IsNullOrEmpty(joinInput.text))
        {
            joinInputPlaceHolder.text = "Room name can't be empty";
        }
        else
        {
            PhotonNetwork.JoinRoom(joinInput.text);
        }
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Photon Master Server.");
    }

    public override void OnJoinedRoom()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            //   Debug.Log("Joined room as master client. Starting gameplay scene.");
            PhotonNetwork.RaiseEvent(1, null, RaiseEventOptions.Default, SendOptions.SendReliable);
        }
        else
        {
            //  Debug.Log("Joined room as client. Waiting for gameplay scene to start.");
        }
        PhotonNetwork.LoadLevel("Camera");
    }
}
