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
    private int multiplayerAvatarInt;
    private void Awake()
    {
        multiplayerAvatarInt = PlayerPrefs.GetInt("CharacterInt");
    }
    void Start()
    {
        canvasName.SetActive(true);
        nameText.text = photonView.Controller.NickName;
        ShowCharacterMultiplayer();
    }
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(multiplayerAvatarInt);
        }
        else if (stream.IsReading)
        {
            multiplayerAvatarInt = (int)stream.ReceiveNext();
            ShowCharacterMultiplayer();
            ReadPotionColors(stream);

        }

    }
    private void ReadPotionColors(PhotonStream stream)
    {
        int colorCount = (int)stream.ReceiveNext();
        receivedPotionColors = new Color[colorCount];
        for (int i = 0; i < colorCount; i++)
        {
            receivedPotionColors[i] = (Color)stream.ReceiveNext();
        }
        ApplyPotionColor();
    }
    private void ApplyPotionColor()
    {
        if (Potions != null && receivedPotionColors != null && Potions.Length == receivedPotionColors.Length)
        {

            for (int i = 0; i < Potions.Length; i++)
            {
                Image potion = Potions[i];
                Color potionColor = receivedPotionColors[i];
                if (potion != null)
                {
                    potion.color = potionColor;
                }
            }
        }
        else
        {
            Debug.LogWarning("Potions array or receivedPotionColors array is null or has mismatched lengths.");
        }
    }

    private void ShowCharacterMultiplayer()
    {
        imageDisplayGameObject.sprite = imageToActive[multiplayerAvatarInt];

    }
}

