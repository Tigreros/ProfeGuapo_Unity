using UnityEngine;

[CreateAssetMenu( menuName = "Weapons/Weapon")]
public class WeaponData : ScriptableObject
{
    public string weaponName;
    public float damage; // 5
    public float range;
    public GameObject weaponPrefab;
    public int level = 1; // 

    //--------------------- Expansion WeaponData --------------------//
    public WeaponRarity rarity = WeaponRarity.Commom;

    public StatusEffectType effectType = StatusEffectType.None;


    public WeaponData CloneAndUpgrade()
    {
        WeaponData clone = Instantiate(this); 
        clone.level = this.level + 1;
        clone.damage += 5 * clone.level;


        if (clone.level >= 3)
        {
            clone.rarity = WeaponRarity.Rare;
            if (clone.effectType == StatusEffectType.None)
            {
                clone.effectType = StatusEffectType.Burn;
            }
        }

        if(clone.level >=5)
        {
            clone.rarity = WeaponRarity.Epic;

            if (clone.effectType == StatusEffectType.Burn)
            {
                clone.effectType = StatusEffectType.Freeze;
            }
        }

        if (clone.level >=7)
        {
            clone.rarity = WeaponRarity.Legendary;
            if (clone.effectType == StatusEffectType.Freeze)
            {
                clone.effectType = StatusEffectType.Poison;
            }
        }


        clone.weaponName = this.weaponName + $" + {clone.level}";
        return clone;
    }
}