using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "Combat/Attack")]
public class AttackData : ScriptableObject
{
    public string attackName;
    public int damage;
    public string description;
    public StatusEffectType attackEffect;
    public Sprite icon;
}
