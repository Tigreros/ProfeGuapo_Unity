using System.Collections;
using UnityEngine;

public class StungSystem : MonoBehaviour
{
    private void OnEnable()
    {
        EventBusBoom.Subscribe("Stung", AplicarStung);
    }

    private void OnDisable()
    {
        EventBusBoom.Unsubscribe("Stung", AplicarStung);

    }


    public void AplicarStung(Vector3 pos, float timeStuned, float radius)
    {
        bool control = false;

        if (Vector3.Distance(pos, transform.position) < radius)
        {
            Debug.DrawRay(new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), pos - transform.position, Color.red, radius);

            RaycastHit[] hits = Physics.RaycastAll(new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), pos - transform.position, Vector3.Distance(pos, transform.position));
            foreach (RaycastHit hit in hits)
            {
                if (hit.collider != null)
                {
                    if (hit.collider.CompareTag("Obstacles"))
                    {
                        control = true;
                    }
                }
            }

            if (!control)
            {
                GetComponent<EnemyBasic>().StungCall(timeStuned);
            }
        }
    }
}
