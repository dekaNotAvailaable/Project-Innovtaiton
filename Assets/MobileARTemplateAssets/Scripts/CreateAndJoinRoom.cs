using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;

public class CreateAndJoinRoom : MonoBehaviourPunCallbacks
{
    public TMP_InputField createInput;
    public TMP_InputField joinInput;
    private SoundEffects soundEffects;

    private void Start()
    {
        soundEffects = FindAnyObjectByType<SoundEffects>();
        ConnectToPhoton(); // Connect to Photon Master Server when the script starts

        // Subscribe to the SceneManager.sceneLoaded event
        //  SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void ConnectToPhoton()
    {
        if (!PhotonNetwork.IsConnected)
        {
            PhotonNetwork.ConnectUsingSettings(); // Connect using Photon settings from the PhotonServerSettings asset
        }
    }

    public void CreateRoom()
    {
        if (!PhotonNetwork.IsConnected)
        {
            Debug.LogWarning("Not connected to Photon Master Server. Waiting to establish connection.");
            return;
        }

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
        if (!PhotonNetwork.IsConnected)
        {
            Debug.LogWarning("Not connected to Photon Master Server. Waiting to establish connection.");
            return;
        }

        if (string.IsNullOrEmpty(joinInput.text))
        {
            joinInput.text = "Room name can't be empty";
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
            Debug.Log("Joined room as master client. Starting gameplay scene.");

            // Raise an event to all players to initialize potion colors in the gameplay scene
            PhotonNetwork.RaiseEvent(1, null, RaiseEventOptions.Default, SendOptions.SendReliable);
        }
        else
        {
            Debug.Log("Joined room as client. Waiting for gameplay scene to start.");
        }
        // Load the gameplay scene
        PhotonNetwork.LoadLevel("Camera");
    }

    // Called when a scene is loaded
    //private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    //{
    //    if (scene.name == "Camera")
    //    {
    //        // Find the PoitionColor component in the gameplay scene
    //        PoitionColor potionColor = FindObjectOfType<PoitionColor>();
    //        if (potionColor != null)
    //        {
    //            // Initialize potion colors in the gameplay scene
    //            if (photonView.IsMine)
    //            {
    //                potionColor.InitializePotionColors();
    //                Debug.Log("Potion iniiztilate color");
    //            }
    //        }
    //        else
    //        {
    //            Debug.LogWarning("PoitionColor component not found in the gameplay scene.");
    //        }
    //    }
    //}

    // Other Photon callbacks can be implemented as needed for error handling and additional functionality

    // Add your SoundEffects or FindAnyObjectByType method here if necessary
}
