using System;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{

    public int healthAmount = 10;
    public float range = 2.0f;
    public KeyCode actionKey = KeyCode.X;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(actionKey))
        {
            TryHeal();
        }
    }

    private void TryHeal()
    {
        RaycastHit hit;

        if (Physics.Raycast(gameObject.transform.GetChild(6).transform.position, transform.forward, out hit, range))
        {
            IHealable healable= hit.collider.GetComponent<IHealable>();
            if (healable != null)
            {
                healable.Heal(healthAmount);
            }
            else
            {
                Debug.Log("Este objeto no es curable");
            }
        }
    }
}
