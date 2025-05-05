using UnityEngine;

public class VidaFlick : MonoBehaviour, IHitable
{
    public int flickLife = 6;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LifeManager.lifeManagerInstance.ReferenceManager(this.gameObject);
    }

    public void TakeHit(float damage, WeaponData weapon)
    {
        flickLife -= Mathf.RoundToInt(damage);
        LifeManager.lifeManagerInstance.gestorVida();
    }
}
