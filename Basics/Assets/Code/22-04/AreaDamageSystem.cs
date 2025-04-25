using UnityEngine;

public class AreaDamageSystem : MonoBehaviour
{

    private void OnEnable()
    {
        EventBusBoom.Subscribe("AreaDamage", AplicarDamageArea);
    }

    private void OnDisable()
    {
        EventBusBoom.Unsubscribe("AreaDamage", AplicarDamageArea);

    }


    public void AplicarDamageArea(Vector3 pos, float damage, float radius)
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

            if(!control)
            {
                GetComponent<IHitable>().TakeHit(damage, null);
            }
        }
    }
}
