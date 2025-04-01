using UnityEngine;

public class FireEffect : IWeaponEffect
{
    public void ApplyEffect(GameObject target) => Debug.Log("El enemigo se quema");
}
