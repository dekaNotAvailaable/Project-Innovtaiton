using Photon.Pun;
using TMPro;

public class CreateAndJoinRoom : MonoBehaviourPunCallbacks
{
    public TMP_InputField createInput;
    public TMP_InputField joinInput;
    private SoundEffects soundEffects;
    private void Start()
    {
        soundEffects = FindAnyObjectByType<SoundEffects>();
    }
    public void CreateRoom()
    {
        if (string.IsNullOrEmpty(createInput.text))
        {
            createInput.text = "Room name can't be empty";
        }
        else
        {
            PhotonNetwork.CreateRoom(createInput.text);
        }
    }
    public void JoinRoom()
    {
        if (string.IsNullOrEmpty(joinInput.text))
        {
            joinInput.text = "Room name can't be empty";
        }
        else
        {
            PhotonNetwork.JoinRoom(joinInput.text);
        }
    }
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Camera");
    }
}
