using Photon.Pun;
using UnityEngine.SceneManagement;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    private void Start()
    {
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
    public void DisconnectFromPhoton()
    {
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
}
