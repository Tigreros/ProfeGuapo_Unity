using UnityEngine;

public class I_Enemy : MonoBehaviour, IHitable
{
    public void TakeHit(int damage)
    {
        Debug.Log("Enemigo ha sido golpeao y restara vida");
    }
}
