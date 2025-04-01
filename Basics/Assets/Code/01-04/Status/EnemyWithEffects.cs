using System.Collections;
using UnityEngine;

public class EnemyWithEffects : MonoBehaviour, IStatusEffectReceiver
{

    public int health = 100;

    public void ApplyEffect(StatusEffect effect)
    {
        Debug.Log($" Efecto recibido es {effect.Type}, por {effect.duration} segundos");

        if (effect.Type == StatusEffectType.Poison)
        {
            StartCoroutine(PoisonDamage(effect.duration));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator PoisonDamage(int duration)
    {
        for (int i = 0; i < duration; i++)
        {
            health -= 1;
            yield return new WaitForSeconds(1);
        }
    }
}
