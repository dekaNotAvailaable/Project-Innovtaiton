using Photon.Pun;
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
    private int colorCount;
    private void Awake()
    {
        multiplayerAvatarInt = PlayerPrefs.GetInt("CharacterInt");
    }
    void Start()
    {
        potionColor = FindAnyObjectByType<PoitionColor>();
        canvasName.SetActive(true);
        nameText.text = photonView.Controller.NickName;
        ShowCharacterMultiplayer();
        for (int i = 0; i < Potions.Length; i++)
        {
            Color potionColor1 = potionColor.GetPotionColor(i);
            if (i < Potions.Length)
            {
                Potions[i].color = potionColor1;
            }
        }
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
            ReadPotionColors(stream);
        }

    }
    private void SendPotionColors(PhotonStream stream)
    {
        for (int i = 0; i < potionColor.Potions.Length; i++)
        {
            Color potionColor1 = potionColor.GetPotionColor(i);
            stream.SendNext(potionColor1.r);
            stream.SendNext(potionColor1.g);
            stream.SendNext(potionColor1.b);
            stream.SendNext(potionColor1.a);
        }
    }
    private void ReadPotionColors(PhotonStream stream)
    {
        if (potionColor != null && potionColor.Potions != null)
        {
            for (int i = 0; i < potionColor.Potions.Length; i++)
            {
                float r = (float)stream.ReceiveNext();
                float g = (float)stream.ReceiveNext();
                float b = (float)stream.ReceiveNext();
                float a = (float)stream.ReceiveNext();
                Color potionColor = new Color(r, g, b, a);
                if (i < Potions.Length)
                {
                    Potions[i].color = potionColor;
                }
            }
        }
    }
    private void ShowCharacterMultiplayer()
    {
        imageDisplayGameObject.sprite = imageToActive[multiplayerAvatarInt];
    }
}

