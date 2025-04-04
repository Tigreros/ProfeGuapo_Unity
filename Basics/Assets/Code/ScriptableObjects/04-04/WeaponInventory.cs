using System.Collections.Generic;
using UnityEngine;

public class WeaponInventory : MonoBehaviour
{

    public List<WeaponData> inventory = new List<WeaponData>();
    public WeaponData equippedWeapon;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            EquipWeaponbyIndex(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            EquipWeaponbyIndex(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            EquipWeaponbyIndex(2);
        }
    }

    public void AddWeapon(WeaponData newWeapon)
    {
        WeaponData existing = inventory.Find(w => w.weaponName == newWeapon.weaponName);
        
        if (existing != null)
        {
            WeaponData upgrade = newWeapon.CloneAndUpgrade();
            inventory.Remove(existing);
            inventory.Add(upgrade);
            equippedWeapon = upgrade;
            Debug.Log($"Arma {upgrade.weaponName} mejorada y equipada.");
        }
        else
        {
            inventory.Add(newWeapon);
            equippedWeapon = newWeapon;
            Debug.Log($"Arma {newWeapon.weaponName} se ha equipado.");
        }
    }

    public void EquipWeaponbyIndex(int index)
    {
        if (index >= 0 && index < inventory.Count)
        { 
            equippedWeapon = inventory[index];
            Debug.Log($"Te equipaste {equippedWeapon.weaponName} con un daño de ( {equippedWeapon.damage} Pts )");
        }
    }

}
