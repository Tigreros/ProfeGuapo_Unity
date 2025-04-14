using System.Collections.Generic;
using UnityEngine;

public class WeaponInventory : MonoBehaviour
{

    public List<WeaponData> inventory = new List<WeaponData>();
    public WeaponData equippedWeapon;

    public int index = 0;

    public bool autoFusion;


    private void Update()
    {
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
        if (autoFusion)
        {

            print(newWeapon);

            bool fusionOcurriendo = true;

            while (fusionOcurriendo)
            {
                fusionOcurriendo = false;

                WeaponData existing = inventory.Find(w => w.weaponName == newWeapon.weaponName);

                if (existing != null)
                {
                    newWeapon = newWeapon.CloneAndUpgrade();
                    inventory.Remove(existing);
                    WeaponUIManager.instance_WeaponManager.RemoveWeaponUpgrade(existing);
                    fusionOcurriendo = true;
                }
            }
        }

        inventory.Add(newWeapon);
        WeaponUIManager.instance_WeaponManager.GetCurrentWeaponData(newWeapon);
        equippedWeapon = newWeapon;
    }

    public void EquipWeaponbyIndex(int index)
    {
        if (index >= 0 && index < inventory.Count)
        { 
            equippedWeapon = inventory[index];
            //Debug.Log($"Te equipaste {equippedWeapon.weaponName} con un daño de ( {equippedWeapon.damage} Pts )");
        }
    }

}
