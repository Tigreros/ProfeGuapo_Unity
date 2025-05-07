using UnityEngine;

[System.Serializable]
public class WeaponSaveData
{
    public string weaponName;
    public float damage; 
    public float range;
    public int level;
    public string description;
    public bool isSelected;
    public float stungTime;

    public WeaponRarity rarity;
    public StatusEffectType effectType;

    // Estos antes eran un GameObject y un Sprites
    //public string weaponPrefab;
    public string icon;
    public string image;
}