using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoitionColor : MonoBehaviour
{
    public Image[] Potions;
    public Color[] potionColors;
    private HashSet<int> destroyedPotions = new HashSet<int>();
    private FreezePotion freezePotion;
    private ImmunityPotion immunityPotion;
    private LevelChange lvlChange;
    void Start()
    {
        freezePotion = FindAnyObjectByType<FreezePotion>();
        immunityPotion = FindAnyObjectByType<ImmunityPotion>();
        lvlChange = FindAnyObjectByType<LevelChange>();
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
    public bool IsPotionDestroyed(int potionIndex)
    {
        return destroyedPotions.Contains(potionIndex);
    }
    private void GameFinish()
    {
        lvlChange.NextScene("Finish Game");
    }
    public void DestroyPotion(int potionIndex)
    {
        if (Potions != null && potionIndex >= 0 && potionIndex < Potions.Length)
        {
            Destroy(Potions[potionIndex].gameObject);
            destroyedPotions.Add(potionIndex);
            if (destroyedPotions.Count <= 0) 
            {
                GameFinish();
            }
            if (Random.value < 0.5f)
            {
                GetFreezePotion();
            }
            else
            {
                GetImmuntyPotion();
            }
        }
        else
        {
            Debug.LogWarning("Invalid potion index provided.");
        }
    }
    private void Update()
    {
        Debug.Log("freeze potion:" + freezePotion.FreezePotionInt + "immunity potion:" + immunityPotion.ImmunityPotionInt);
    }
    private void GetFreezePotion()
    {
        freezePotion.FreezePotionInt++;
    }
    private void GetImmuntyPotion()
    {
        immunityPotion.ImmunityPotionInt++;
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
            return Color.white;
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
}
