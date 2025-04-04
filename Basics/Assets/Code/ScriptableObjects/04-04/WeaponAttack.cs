using System;
using UnityEngine;

public class WeaponAttack : MonoBehaviour
{

    public WeaponInventory inventory;
    public KeyCode attackKey = KeyCode.Mouse0;

    public Transform attackPoint;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(attackKey) && inventory.equippedWeapon != null)
        {
            Attack();
        }
    }

    private void Attack()
    {
        WeaponData weapon = inventory.equippedWeapon;
        attackPoint = GameObject.Find("AttackPoint").transform;

        RaycastHit hit;

        if(Physics.Raycast(attackPoint.transform.position, attackPoint.transform.forward, out hit, weapon.range))
        {
            IHitable target = hit.collider.GetComponent<IHitable>();

            if(target != null)
            {
                target.TakeHit(weapon.damage);
                Debug.Log($"Hemos atacado con {weapon.weaponName}. Con un daño de : {weapon.damage} Pts.");
            }
        }
    }
}
