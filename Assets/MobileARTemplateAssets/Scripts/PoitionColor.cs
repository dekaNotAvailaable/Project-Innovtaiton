using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class PoitionColor : MonoBehaviourPunCallbacks, IPunObservable
{
    public Image[] Potions;
    public Color[] potionColors;

    void Start()
    {
        if (photonView.IsMine)
        {
            // If this is the local player, assign random potion colors
            AssignRandomPotionColors();
            Debug.Log("Check if the view is mine (should only appear in master client)");
            SendPotionColors();
        }
    }

    public void AssignRandomPotionColors()
    {
        foreach (Image potion in Potions)
        {
            if (potion != null && potionColors.Length > 0)
            {
                Color randomColor = potionColors[Random.Range(0, potionColors.Length)];

                // Assign random Color directly to potion image
                randomColor.a = 1;
                potion.color = randomColor;
            }
            else
            {
                Debug.LogWarning("Image component not found on a potion GameObject or no colors available.");
            }
        }
    }

    [PunRPC]
    void SendPotionColorsToClients(Vector3[] colors)
    {
        // Update potion colors with the received data
        for (int i = 0; i < Potions.Length && i < colors.Length; i++)
        {
            Color color = new Color(colors[i].x, colors[i].y, colors[i].z);
            Potions[i].color = color;
        }
    }

    void SendPotionColors()
    {
        // Convert Color array to Vector3 array before sending
        Vector3[] colors = new Vector3[potionColors.Length];
        for (int i = 0; i < potionColors.Length; i++)
        {
            colors[i] = new Vector3(potionColors[i].r, potionColors[i].g, potionColors[i].b);
        }

        photonView.RPC("SendPotionColorsToClients", RpcTarget.OthersBuffered, colors);
    }

    // Other clients receive potion colors from the master client
    [PunRPC]
    void ReceivePotionColorsFromMaster(Vector3[] colors)
    {
        // Update potion colors with the received data
        for (int i = 0; i < Potions.Length && i < colors.Length; i++)
        {
            Color color = new Color(colors[i].x, colors[i].y, colors[i].z);
            Potions[i].color = color;
        }
    }

    public void DestroyPotion(int potionIndex)
    {
        if (Potions != null && potionIndex >= 0 && potionIndex < Potions.Length)
        {
            Destroy(Potions[potionIndex].gameObject);
        }
        else
        {
            Debug.LogWarning("Invalid potion index provided.");
        }
    }

    public Color GetPotionColor(int potionIndex)
    {
        if (potionIndex >= 0 && potionIndex < Potions.Length)
        {
            return Potions[potionIndex].color;
        }
        else
        {
            Debug.LogWarning("Invalid potion index provided.");
            return Color.white; // Return default color
        }
    }

    public int GetActivePotionCount()
    {
        int count = 0;
        foreach (Image potion in Potions)
        {
            if (potion != null)
            {
                count++;
            }
        }
        return count;
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        // Implement serialization logic here if needed
    }
}
