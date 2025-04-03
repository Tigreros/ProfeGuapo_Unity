using UnityEngine;

[CreateAssetMenu( menuName = "Weapons/Weapon")]
public class WeaponData : ScriptableObject
{
    public string weaponName;
    public int damage;
    public float range;
    public GameObject weaponPrefab;
}