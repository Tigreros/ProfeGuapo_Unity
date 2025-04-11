using System.Collections.Generic;
using UnityEngine;

public class WeaponInventory : MonoBehaviour
{

    public List<WeaponData> inventory = new List<WeaponData>();
    public WeaponData equippedWeapon;

    public int index = 0;

    private void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Alpha1))
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
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            EquipWeaponbyIndex(2);
        }*/


        if(Input.mouseScrollDelta.y != 0)
        {
            index = Mathf.RoundToInt(Input.mouseScrollDelta.y) + index;

            if(index > (inventory.Count - 1)) index = 0;
            if(index < 0) index = (inventory.Count - 1);

            EquipWeaponbyIndex(index);
        }
    }

    public void AddWeapon(WeaponData newWeapon)
    {
        bool fusionOcurriendo = true;

        while (fusionOcurriendo)
        {
            fusionOcurriendo = false;

            WeaponData existing = inventory.Find(w => w.weaponName == newWeapon.weaponName);

            if (existing != null)
            {
                //Debug.Log($"Fusinamos dos {newWeapon.weaponName} de nivel {newWeapon.level}");
                inventory.Remove(existing);
                newWeapon = newWeapon.CloneAndUpgrade();
                WeaponUIManager.instance_WeaponManager.GetCurrentWeaponData(newWeapon);
                fusionOcurriendo = true;
            }
        }

        inventory.Add(newWeapon);
        equippedWeapon = newWeapon;
        //Debug.Log($" Arma final equipada: {newWeapon.weaponName} , nivel({newWeapon.level})");
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
