using NUnit.Framework.Internal.Filters;
using Unity.VisualScripting;
using UnityEngine;

public class MegamanAttack : MonoBehaviour
{

    public Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void LanzarAttak()
    {
        animator.SetBool("Attack", true);
    }

    public void CheckAttack()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.GetChild(1).position, 2, transform.right, 2);

        foreach (RaycastHit2D hit in hits)
        {
            IHitable target = hit.collider.GetComponent<IHitable>();

            if (target != null)
            {
                target.TakeHit(1, null);
            }
        }
    }

    public void ReturnToIdle()
    {
        animator.SetBool("Attack", false);
    }
}
