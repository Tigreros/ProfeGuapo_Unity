using System.Collections;
using UnityEngine;

public class Bomba : MonoBehaviour
{
    public float thrust = 1.0f;
    public Rigidbody rb;

    public float damage;
    public float radius;

    public float time;
    public bool boomFreeze;
    public float boomFreezeTimerStung;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine("CACA");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            if (!boomFreeze)
            {
                EventBusBoom.Publish("AreaDamage", transform.position, damage, radius);
            }
            else
            {
                EventBusBoom.Publish("Stung", transform.position, boomFreezeTimerStung, radius);
            }
        }
    }

    IEnumerator CACA()
    {
        yield return new WaitForSeconds(time);
        rb.useGravity = true;
        rb.AddForce(thrust, thrust, 0, ForceMode.Impulse);
    }

}
