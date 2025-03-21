using UnityEngine;

public class Salto : MonoBehaviour
{
    public float jumpForce;
    public Rigidbody rb;
    public Vector3 direccionSalto;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        jumpForce = 8;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Salto") && rb.linearVelocity.y == 0)
        {
            Jump();
        }

        if(rb.linearVelocity.y != 0)
        {
            Debug.Log("Estas cayendo");
        }
        else
        {
            Debug.Log("Estoy tocando suelo");
        }

    }

    [ContextMenu("Saltar")]
    void Jump()
    {
        rb.AddForce(direccionSalto * jumpForce, ForceMode.Impulse);
    }
}
