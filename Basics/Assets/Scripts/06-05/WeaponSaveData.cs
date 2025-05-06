using UnityEngine;

[System.Serializable]
public class WeaponSaveData
{
    public string weaponName;
    public float damage; 
    public float range;
    public GameObject weaponPrefab;
    public int level;

    public string description;
    public Sprite icon;
    public Sprite image;
    public bool isSelected;
    public float stungTime;

    public WeaponRarity rarity;
    public StatusEffectType effectType;
}