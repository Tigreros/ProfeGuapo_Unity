using UnityEngine;

public class WeaponWithEffect : MonoBehaviour
{

    public float attackRange = 2.0f;
    public int attackeffect = 0;
    public KeyCode attackKey = KeyCode.Mouse0;

    private IWeaponEffect effect = new FireEffect();


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(attackKey))
        {
            TryAttack();
        }

        Debug.DrawRay(gameObject.transform.GetChild(6).transform.position, transform.forward * attackRange, Color.red);

        switch (attackeffect)
        {
            case 0:
                effect = new FireEffect();
                break;

            case 1:
                effect = new IceEffect();
                break;

            default:
                effect = new Normaleffect();
                break;
        }
    }

    private void TryAttack()
    {
        RaycastHit hit;

        if (Physics.Raycast(gameObject.transform.GetChild(6).transform.position, transform.forward, out hit, attackRange))
        {
            IHitable target = hit.collider.gameObject.GetComponent<IHitable>();

            if (target != null)
            {
                target.TakeHit();
                effect?.ApplyEffect(hit.collider.gameObject);
            }
        }


    }
}
