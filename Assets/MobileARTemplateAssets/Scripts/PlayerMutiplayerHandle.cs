#pragma warning disable CS0220 
using Photon.Pun;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMutiplayerHandle : MonoBehaviourPunCallbacks, IPunObservable
{
    public GameObject canvasName;
    public TMP_Text nameText;
    public TMP_Text potionCount;
    public Image imageDisplayGameObject;
    public Sprite[] imageToActive;
    public Image[] Potions;
    public Color[] receivedPotionColors;
    private PoitionColor potionColor;
    private int multiplayerAvatarInt;
    private bool isStartLoopFinished = false;
    private int remainingPotionCount;
    private void Awake()
    {
        potionColor = FindAnyObjectByType<PoitionColor>();
        multiplayerAvatarInt = PlayerPrefs.GetInt("CharacterInt");
        remainingPotionCount = potionColor.GetActivePotionCount();
    }
    void Start()
    {
        StartCoroutine(StartLoop());
        canvasName.SetActive(true);
        nameText.text = photonView.Controller.NickName;
        potionCount.text = remainingPotionCount.ToString();
        ShowCharacterMultiplayer();
    }
    IEnumerator StartLoop()
    {
        for (int i = 0; i < Potions.Length; i++)
        {
            receivedPotionColors[i] = potionColor.GetPotionColor(i);
            if (i < Potions.Length)
            {
                Potions[i].color = receivedPotionColors[i];
                // Debug.Log("Local colors:" + receivedPotionColors[i]);
            }
        }
        isStartLoopFinished = true;
        yield return null;
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(multiplayerAvatarInt);
            SendPotionIndex(stream);
            SendPotionColors(stream);
        }
        else if (stream.IsReading)
        {
            multiplayerAvatarInt = (int)stream.ReceiveNext();
            ShowCharacterMultiplayer();
            ReadPotionIndex(stream);
            if (isStartLoopFinished)
            {
                ReadPotionColors(stream);
                //  Debug.Log("Start loop is finishewd reading colors ");
            }
            else
            {
                StartCoroutine(ApplyPotionAfterJoined(stream));
                // Debug.Log("start loop isnt finished so running coroutine insted");
            }
        }
    }
    private void ReadPotionIndex(PhotonStream stream)
    {
        remainingPotionCount = (int)stream.ReceiveNext();
        potionCount.text = remainingPotionCount.ToString();
    }
    private void SendPotionIndex(PhotonStream stream)
    {
        stream.SendNext(potionColor.GetActivePotionCount());

    }
    private void SendPotionColors(PhotonStream stream)
    {
        for (int i = 0; i < Potions.Length; i++)
        {
            receivedPotionColors[i] = potionColor.GetPotionColor(i);
            stream.SendNext(receivedPotionColors[i].r);
            stream.SendNext(receivedPotionColors[i].g);
            stream.SendNext(receivedPotionColors[i].b);
        }
    }
    private void ReadPotionColors(PhotonStream stream)
    {
        for (int i = 0; i < Potions.Length; i++)
        {
            receivedPotionColors[i].r = (float)stream.ReceiveNext();
            receivedPotionColors[i].g = (float)stream.ReceiveNext();
            receivedPotionColors[i].b = (float)stream.ReceiveNext();
            if (i < Potions.Length)
            {
                Potions[i].color = receivedPotionColors[i];
            }
        }
    }
    IEnumerator ApplyPotionAfterJoined(PhotonStream stream)
    {
        yield return null;
        ReadPotionColors(stream);
    }
    private void ShowCharacterMultiplayer()
    {
        imageDisplayGameObject.sprite = imageToActive[multiplayerAvatarInt];
    }

    public void ActivateFreezePotionOnOtherClients()
    {
        if (PhotonNetwork.IsConnected)
        {
            photonView.RPC("ActivateFreezePotionRPC", RpcTarget.Others);
        }
    }

    [PunRPC]
    private void ActivateFreezePotionRPC()
    {
        FindObjectOfType<FreezePotion>().ApplyFreezePotion();
    }
}
#pragma warning restore CS0220
