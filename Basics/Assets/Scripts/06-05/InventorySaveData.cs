using System.Collections.Generic;

[System.Serializable]
public class InventorySaveData 
{
    public List<WeaponSaveData> inventory = new();
    public WeaponSaveData equippedWeapon;
}
