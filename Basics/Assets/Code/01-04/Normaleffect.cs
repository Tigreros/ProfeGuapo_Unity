using UnityEngine;

public class Normaleffect : IWeaponEffect
{
    public void ApplyEffect(GameObject target) => Debug.Log("Nada especial, solo el golpe");
}
