using UnityEngine;

public class StatusWeapon : MonoBehaviour
{

    public StatusEffectType effectType = StatusEffectType.Poison;
    public int effectDuration = 5;
    public float range = 2f;
    public KeyCode attackKey = KeyCode.Mouse0;

    public GameObject from;

    private void Start()
    {
        from = GameObject.Find("AttackPoint");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(attackKey))
        {
            TryApplyEffect();
        }

        Debug.DrawRay(from.transform.position, from.transform.forward * range, Color.red);

    }
    private void TryApplyEffect()
    {
        RaycastHit hit;

        if (Physics.Raycast(from.transform.position, from.transform.forward, out hit, range))
        {
            Debug.Log("He colisionado con: " + hit.collider.name);
            IStatusEffectReceiver receiver = hit.collider.GetComponent<IStatusEffectReceiver>();
            if (receiver != null)
            {
                receiver.ApplyEffect(new StatusEffect(effectType, effectDuration));
            }
        }
        else
        {
            Debug.Log("no hemos colisionado con nada");
        }
    }
}
