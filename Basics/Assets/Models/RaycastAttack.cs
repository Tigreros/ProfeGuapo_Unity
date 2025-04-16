using System;
using UnityEngine;
using static UnityEngine.UI.Image;

public class RaycastAttack : MonoBehaviour
{

    public float attackRange = 2.0f;
    public KeyCode attackKey = KeyCode.Mouse0;

    public GameObject[] debugGamObject;
    
    //public 

    void Update()
    {
        Debug.DrawRay(gameObject.transform.GetChild(6).transform.position, gameObject.transform.GetChild(6).transform.forward * attackRange, Color.green);

        if (Input.GetKeyDown(attackKey))
        {
            TryAttack();
        }
    }

    /*private void TryAttack()
    {
        RaycastHit hit;
        Vector3 origin = transform.position;
        Vector3 direction = transform.forward;

        if(Physics.Raycast(origin, direction, out hit, attackRange))
        {
            IHitable target = hit.collider.GetComponent<IHitable>();

            if (target != null) 
            {
                target.TakeHit();
            }
            else
            {
                Debug.Log("El rayo o el ataque ha golpeado algo que no se puede romper");
            }
        }
        else
        {
            Debug.Log("El ataque no ha golpeado nada");
        }
    }*/


    private void TryAttack()
    {

        Vector3 origin = transform.position;
        Vector3 direction = transform.forward;

        RaycastHit[] hits = Physics.RaycastAll(origin, direction, attackRange);

        int i = -1;
        debugGamObject = new GameObject[hits.Length];

        foreach (RaycastHit hit in hits)
        {
            {
                i++;
                IHitable target = hit.collider.GetComponent<IHitable>();

                debugGamObject[i] = hit.collider.gameObject;

                if (target != null)
                {
                    //target.TakeHit(1);
                }
                else
                {
                    Debug.Log("El rayo o el ataque ha golpeado algo que no se puede romper");
                }
            }
        }
    }
}
