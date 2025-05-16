using UnityEngine;

public class I_Candle : MonoBehaviour, IHitable, IHealable, IStatusEffectReceiver
{

    public int health = 100;

    public GameObject[] dropObject;

    public void Heal(int amount)
    {
        if (this.enabled)
        {
            health += amount;
            Debug.Log($"{gameObject.name} recibio {amount} de curación. Vida actual: {health}");
        }
    }

    public void TakeHit(float damage, WeaponData weapon)
    {
        //dropObject = new WeaponData[3];

        if (this.enabled)
        {
            Debug.Log("Vela se rompe " + transform.name + "damage: " + damage);
            health -= Mathf.RoundToInt(damage);
            //Debug.Log($"{gameObject.name} recibio {damage} de daño. Vida actual: {health}");
            //Instantiate(dropObject[Random.Range(0, 3)], transform.position, transform.rotation);
            //CreatePoolVisualDamage.Instance.AssingVisualDamageFunction(this.gameObject, damage);

            //Destroy(gameObject);
        }
    }

    public void ApplyEffect(StatusEffect effect)
    {
        Debug.Log("Le hemos aplicado: " + effect);
        Destroy(gameObject);
    }

}
