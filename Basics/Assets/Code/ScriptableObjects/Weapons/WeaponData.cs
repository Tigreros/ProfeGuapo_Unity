using UnityEngine;

[CreateAssetMenu( menuName = "Weapons/Weapon")]
public class WeaponData : ScriptableObject
{
    public string weaponName;
    public float damage; // 5
    public float range;
    public GameObject weaponPrefab;
    public int level = 1; // 

    [TextAreaAttribute(2,6)]
    public string description;

    public Sprite icon;
    public Sprite image;

    public bool isSelected;

    public float stungTime;


    //--------------------- Expansion WeaponData --------------------//
    public WeaponRarity rarity = WeaponRarity.Commom;

    public StatusEffectType effectType = StatusEffectType.None;


    public WeaponData CloneAndUpgrade()
    {
        WeaponData clone = Instantiate(this);

        clone.level = this.level + 1;
        clone.damage += 5 * clone.level;


        clone.rarity = this.rarity;
        clone.effectType = this.effectType;
        clone.weaponName = this.weaponName + $" + {clone.level}";

        return clone;
    }
}