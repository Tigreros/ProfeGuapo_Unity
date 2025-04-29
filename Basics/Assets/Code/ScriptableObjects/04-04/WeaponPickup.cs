using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    // Este script es para el objeto que se va a ecoger (Espada, axe, mace)
    public WeaponData weaponToGive;

    public void OnTriggerEnter(Collider other)
    {
        WeaponInventory inv = other.GetComponent<WeaponInventory>();
        //InventoryNavigation nav = other.GetComponent<InventoryNavigation>().FindChildren();

        if(inv != null)
        {
            inv.AddWeapon(weaponToGive);
            ManagerLog.instance_Log.Log($"Hemos recogido, {weaponToGive.weaponName} ({weaponToGive.rarity})" , "pickUp");
            //Debug.Log(weaponToGive.description);
            //Debug.Log($" El arma recogida es: {weaponToGive.weaponName}");
            Destroy(gameObject);
        }
    }

}
