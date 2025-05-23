using UnityEngine;

public class WeaponAttack : MonoBehaviour
{

    public WeaponInventory inventory;
    public KeyCode attackKey = KeyCode.Mouse0;
    public KeyCode attackKeyD = KeyCode.Mouse1;

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
            Attack(false);
        }

        if (Input.GetKeyDown(attackKeyD) && inventory.equippedWeapon != null)
        {
            Attack(true);
        }
        //Debug.DrawRay(attackPoint.transform.position, attackPoint.transform.forward * 1.5f, Color.yellow, 2);
    }

    private void Attack(bool isMagic)
    {
        WeaponData weapon = inventory.equippedWeapon;

        if (!isMagic)
        {
            RaycastHit hit;

            if (Physics.Raycast(attackPoint.transform.position, attackPoint.transform.forward, out hit, weapon.range))
            {
                //Debug.DrawRay(attackPoint.transform.position, attackPoint.transform.forward * weapon.range, Color.yellow, 2);
                IHitable target = hit.collider.GetComponent<IHitable>();

                if (target != null)
                {
                    if (Vector3.Angle(hit.collider.transform.forward, attackPoint.transform.forward) < 50)
                    {
                        //Debug.Log("He golpeado por la espalda");
                        BattleManagerPersistant.instance_BattleManagerPersistant.LoadBattleScene(0,true);
                    }
                    else
                    {
                        //Debug.Log("He comenzado combate");
                        BattleManagerPersistant.instance_BattleManagerPersistant.LoadBattleScene(0, System.Convert.ToBoolean(UnityEngine.Random.Range(0, 2)));
                    }

                    //float multiplier = GetDamageMultiplier(weapon.rarity);
                    //float finalDamage = weapon.damage * multiplier;

                    //target.TakeHit(finalDamage, weapon);
                    //Debug.Log($"Hemos atacado con {weapon.weaponName}({weapon.rarity}), y hemos causado {finalDamage} de da�o.");

                    //ApplyEffectIfAny(hit.collider, weapon);
                }
            }
            else
            {
                print("No estas atacando nada bb");
            }
        }
        else
        {
            GameObject enemy = GameObject.Find("patrick_skeleton_m(Clone)");

            if(enemy == null)
            {
                enemy = GameObject.Find("goblin kamikaze(Clone)");
            }
            if (enemy.GetComponent<IHitable>() != null) 
            {
                float multiplier = GetDamageMultiplier(weapon.rarity);
                float finalDamage = weapon.damage * multiplier;

                EventBus.HitPublish("HitObject", enemy, finalDamage);
            }

            
        }
    }

    private float GetDamageMultiplier(WeaponRarity rarity)
    {
        switch (rarity)
        {
            case WeaponRarity.Commom:       return 1.0f;
            case WeaponRarity.Rare:         return 1.2f;
            case WeaponRarity.Epic:         return 1.5f;
            case WeaponRarity.Legendary:    return 2.0f;

            default: return 1.0f;
        }
    }

    private void ApplyEffectIfAny(Collider targetCollider, WeaponData weapon)
    {
        if (weapon.effectType != StatusEffectType.None)
        {
            IStatusEffectReceiver receiver = targetCollider.GetComponent<IStatusEffectReceiver>();
            if (receiver != null)
            {
                receiver.ApplyEffect(new StatusEffect(weapon.effectType, 5));
                Debug.Log("Le hemos aplicado tal efecto: " + weapon.effectType);
            }
        }
    }
}









/*

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

                Debug.Log($"Hemos atacado con {weapon.weaponName}. Con un da�o de : {weapon.damage} Pts.");
*/