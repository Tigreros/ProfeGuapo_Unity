using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "Combat/Cambatant")]
public class CombatantData : ScriptableObject
{

    public string displayName;
    public Sprite portrait;
    public int maxHP;
    public int CurrentHP;
    public List<AttackData> availableAttacks;

}
