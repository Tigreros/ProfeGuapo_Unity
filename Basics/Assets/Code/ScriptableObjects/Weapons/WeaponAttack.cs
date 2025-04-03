using System;
using UnityEngine;

public class WeaponAttack : MonoBehaviour
{

    public WeaponData weaponData;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Attack();
        }
    }

    private void Attack()
    {
        RaycastHit hit;
        Vector3 origin = transform.position;
        Vector3 direction = transform.forward;

        if (Physics.Raycast(origin, direction, out hit, weaponData.range))
        {
            IHitable target = hit.collider.GetComponent<IHitable>();
            if (target != null)
            {
                target.TakeHit(weaponData.damage);
            }
        }
        else
        {
            Debug.Log("No hemos golpeado nada");
        }

        Debug.DrawRay(origin, direction * weaponData.range, Color.blue, 3);
    }
}
