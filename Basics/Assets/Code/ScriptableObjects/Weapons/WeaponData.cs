using UnityEngine;

[CreateAssetMenu( menuName = "Weapons/Weapon")]
public class WeaponData : ScriptableObject
{
    public string weaponName;
    public int damage; // 5
    public float range;
    public GameObject weaponPrefab;
    public int level = 1; // 


    public WeaponData CloneAndUpgrade()
    {
        WeaponData clone = Instantiate(this); 
        clone.level = this.level + 1;
        clone.damage += 2 * clone.level;
        clone.weaponName = this.weaponName + $" + {clone.level}";
        return clone;
    }
}