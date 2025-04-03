using UnityEngine;

public class I_Candle : MonoBehaviour, IHitable, IHealable
{

    private int health = 100;

    public void Heal(int amount)
    {
        if (this.enabled)
        {
            health += amount;
            Debug.Log($"{gameObject.name} recibio {amount} de curación. Vida actual: {health}");
        }
    }

    public void TakeHit(int damage)
    {
        if (this.enabled)
        {
            Debug.Log("Vela se rompe " + transform.name);
            Destroy(gameObject, 1);
        }
    }

}
