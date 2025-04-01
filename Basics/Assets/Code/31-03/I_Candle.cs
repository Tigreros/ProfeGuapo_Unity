using UnityEngine;

public class I_Candle : MonoBehaviour, IHitable, IHealable
{
    public int health = 100;

    public void Heal(int amount)
    {
        health += amount;
        Debug.Log($"{gameObject.name} recibio {amount} de curación. Vida actual: {health}");
    }

    public void TakeHit()
    {
        Debug.Log("Vela se rompe " + transform.name);
        Destroy(gameObject, 1);
    }
}
