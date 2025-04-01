public enum StatusEffectType
{
    Poison,
    Burn,
    Freeze
}

public class StatusEffect
{
    public StatusEffectType Type;
    public int duration;

    public StatusEffect(StatusEffectType type, int duration)
    {
        this.Type = type;
        this.duration = duration;
    }
}

public interface IStatusEffectReceiver
{
    void ApplyEffect(StatusEffect effect);
}