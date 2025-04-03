using UnityEngine;
using UnityEngine.UIElements;

public class AtaqueBaridoAngulo : MonoBehaviour
{
    public float attackRange = 2.0f;
    public KeyCode attackKey = KeyCode.Mouse0;
    public float angleAttack;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //OnDrawGizmosSelected();

        if (Input.GetKeyDown(attackKey))
        {
            TryAttack();
        }
    }

    private void TryAttack()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, attackRange);

        foreach (Collider col in hits)
        {
            Vector3 dirToTraget = (col.transform.position - gameObject.transform.GetChild(6).transform.position).normalized;
            float angle = Vector3.Angle(gameObject.transform.GetChild(6).transform.forward, dirToTraget);

            if (angle <= angleAttack)
            {
                IHitable target = col.GetComponent<IHitable>();
                if (target != null)
                {
                    target.TakeHit(1);
                }
            }
        }
    }
}
