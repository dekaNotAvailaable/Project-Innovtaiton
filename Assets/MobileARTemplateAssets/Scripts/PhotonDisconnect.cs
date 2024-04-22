using Photon.Pun;

public class PhotonDisconnect : MonoBehaviourPunCallbacks
{
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
