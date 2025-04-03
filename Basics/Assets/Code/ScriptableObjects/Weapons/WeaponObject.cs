using UnityEngine;

public class WeaponObject : MonoBehaviour, ObjetosRecoger
{
    public WeaponData weaponData;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Recoger();
            other.GetComponent<CapacidadRecoger>().WhichWeapon(weaponData.weaponName, weaponData.weaponPrefab);
        }
    }
    public void Recoger()
    {
        Destroy(gameObject,0.02f);
    }
}
