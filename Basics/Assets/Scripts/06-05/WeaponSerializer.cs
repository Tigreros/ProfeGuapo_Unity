using UnityEngine;

public static class WeaponSerializer
{
    public static WeaponSaveData 
    ToSaveData(WeaponData data)
    {
        return new WeaponSaveData
        {
            weaponName = data.weaponName,
            damage = data.damage,
            range = data.range,
            level = data.level,
            rarity = data.rarity,
            effectType = data.effectType,
        };
    }

    public static WeaponData
    ToWeaponData(WeaponSaveData saveData, WeaponData baseReference)
    {
        WeaponData clone = ScriptableObject.Instantiate(baseReference);
        clone.weaponName = saveData.weaponName;
        clone.damage = saveData.damage;
        clone.range = saveData.range;
        clone.level = saveData.level;
        clone.rarity = saveData.rarity;
        clone.effectType = saveData.effectType;

        return clone;
    }
}
