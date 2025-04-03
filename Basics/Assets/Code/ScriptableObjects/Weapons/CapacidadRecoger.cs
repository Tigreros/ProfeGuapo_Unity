using UnityEngine;

public class CapacidadRecoger : MonoBehaviour
{

    public GameObject parentPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        parentPrefab = GameObject.Find("FlickNet");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WhichWeapon(string weaponName, GameObject prefab)
    {
        switch (weaponName)
        {
            case "Sword":
                Debug.Log("Sword");
                break;

            case "Axe":
                Debug.Log("Axe");
                break;

            case "Mace":
                Debug.Log("Mace");
                break;
        }

        Instantiate(prefab, parentPrefab.transform.position, parentPrefab.transform.rotation, parentPrefab.transform);
    }
}
