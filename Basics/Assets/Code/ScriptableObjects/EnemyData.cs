using UnityEngine;


[CreateAssetMenu(menuName = "Enemy/Enemigo")]
public class EnemyData : ScriptableObject
{
    public string enemyName;
    public int health;
    public float attack;
    public float speed;
}
