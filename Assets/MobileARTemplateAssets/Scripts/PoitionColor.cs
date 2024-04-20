using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class PoitionColor : MonoBehaviourPunCallbacks, IPunObservable
{
    public Image[] Potions;
    public Color[] potionColors;

    void Start()
    {
        AssignRandomPotionColors();
    }

    public void AssignRandomPotionColors()
    {
        foreach (Image potion in Potions)
        {
            if (potion != null && potionColors.Length > 0)
            {
                Color randomColor = potionColors[Random.Range(0, potionColors.Length)];
                randomColor.a = 1;
                potion.color = randomColor;
            }
            else
            {
                Debug.LogWarning("Image component not found on a potion GameObject or no colors available.");
            }
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
        stream.SendNext(potionColors.Length);
        foreach (Color color in potionColors)
        {
            stream.SendNext(color);
        }
    }
}
