#pragma warning disable CS0220 
using Photon.Pun;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerProfileData : MonoBehaviourPunCallbacks, IPunObservable
{
    public GameObject canvasName;
    public TMP_Text nameText;
    public Image imageDisplayGameObject;
    public Sprite[] imageToActive;
    public Image[] Potions;
    public Color[] receivedPotionColors;
    private PoitionColor potionColor;
    private int multiplayerAvatarInt;
    private bool isStartLoopFinished = false;
    private void Awake()
    {
        potionColor = FindAnyObjectByType<PoitionColor>();
        multiplayerAvatarInt = PlayerPrefs.GetInt("CharacterInt");
    }
    void Start()
    {
        StartCoroutine(StartLoop());
        canvasName.SetActive(true);
        nameText.text = photonView.Controller.NickName;
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
                Debug.Log("Local colors:" + receivedPotionColors[i]);
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
            SendPotionColors(stream);
        }
        else if (stream.IsReading)
        {
            multiplayerAvatarInt = (int)stream.ReceiveNext();
            ShowCharacterMultiplayer();

            if (isStartLoopFinished)
            {
                ReadPotionColors(stream);
                Debug.Log("Start loop is finishewd reading colors ");
            }
            else
            {
                StartCoroutine(ApplyPotionAfterJoined(stream));
                Debug.Log("start loop isnt finished so running coroutine insted");
            }
        }
    }
    private void SendPotionColors(PhotonStream stream)
    {
        for (int i = 0; i < Potions.Length; i++)
        {
            receivedPotionColors[i] = potionColor.GetPotionColor(i);
            stream.SendNext(receivedPotionColors[i].r);
            stream.SendNext(receivedPotionColors[i].g);
            stream.SendNext(receivedPotionColors[i].b);
            stream.SendNext(receivedPotionColors[i].a);
        }
    }
    private void ReadPotionColors(PhotonStream stream)
    {
        for (int i = 0; i < Potions.Length; i++)
        {
            receivedPotionColors[i].r = (float)stream.ReceiveNext();
            receivedPotionColors[i].g = (float)stream.ReceiveNext();
            receivedPotionColors[i].b = (float)stream.ReceiveNext();
            receivedPotionColors[i].a = (float)stream.ReceiveNext();
            Debug.Log("recieved new colors:" + receivedPotionColors[i]);
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
}
#pragma warning restore CS0220
