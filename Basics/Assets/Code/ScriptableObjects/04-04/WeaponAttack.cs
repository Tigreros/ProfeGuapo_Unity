using System;
using UnityEngine;

public class WeaponAttack : MonoBehaviour
{

    public WeaponInventory inventory;
    public KeyCode attackKey = KeyCode.Mouse0;

    public Transform attackPoint;

    public void Start()
    {
        inventory = GetComponent<WeaponInventory>();
        attackPoint = GameObject.Find("AttackPoint").transform;
    }

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
        RaycastHit hit;

        //Debug.Log(weapon.rarity);

        /*switch (weapon.rarity)
        {
            case WeaponRarity.Commom:
                Debug.Log("Atacamos con basica");
                break;
            case WeaponRarity.Rare:
                Debug.Log("Atacamos con rara");
                break;
            case WeaponRarity.Epic:
                Debug.Log("Atacamos con epica");
                break;
            case WeaponRarity.Legendary:
                Debug.Log("Atacamos con legendaria");
                break;
        }*/

        if(Physics.Raycast(attackPoint.transform.position, attackPoint.transform.forward, out hit, weapon.range))
        {
            IHitable target = hit.collider.GetComponent<IHitable>();
            Debug.Log("NOne");

            if(target != null)
            {

                if (weapon.rarity == WeaponRarity.Legendary)
                {
                    target.TakeHit(weapon.damage * 2f);
                    if (weapon.effectType != StatusEffectType.None)
                    {
                        IStatusEffectReceiver receiver = hit.collider.GetComponent<IStatusEffectReceiver>();
                        if (receiver != null)
                        {
                            receiver.ApplyEffect(new StatusEffect(weapon.effectType, 5));
                            Debug.Log("Le hemos aplicado tal efecto: " + weapon.effectType);
                        }
                    }
                }

                else if (weapon.rarity == WeaponRarity.Epic)
                {
                    target.TakeHit(weapon.damage * 1.5f);
                    if (weapon.effectType != StatusEffectType.None)
                    {
                        IStatusEffectReceiver receiver = hit.collider.GetComponent<IStatusEffectReceiver>();
                        if (receiver != null)
                        {
                            receiver.ApplyEffect(new StatusEffect(weapon.effectType, 5));
                            Debug.Log("Le hemos aplicado tal efecto: " + weapon.effectType);
                        }
                    }
                }

                else if (weapon.rarity == WeaponRarity.Rare)
                {
                    target.TakeHit(weapon.damage * 1.2f);
                    if (weapon.effectType != StatusEffectType.None)
                    {
                        IStatusEffectReceiver receiver = hit.collider.GetComponent<IStatusEffectReceiver>();
                        if (receiver != null)
                        {
                            receiver.ApplyEffect(new StatusEffect(weapon.effectType, 5));
                            Debug.Log("Le hemos aplicado tal efecto: " + weapon.effectType);
                        }
                    }
                }
                else if (weapon.rarity == WeaponRarity.Commom)
                {
                    target.TakeHit(weapon.damage);
                    if (weapon.effectType != StatusEffectType.None)
                    {
                        IStatusEffectReceiver receiver = hit.collider.GetComponent<IStatusEffectReceiver>();
                        if (receiver != null)
                        {
                            receiver.ApplyEffect(new StatusEffect(weapon.effectType, 5));
                            Debug.Log("Le hemos aplicado tal efecto: " + weapon.effectType);
                        }
                    }
                }

                Debug.Log($"Hemos atacado con {weapon.weaponName}. Con un daño de : {weapon.damage} Pts.");
            }
        }
    }
}
