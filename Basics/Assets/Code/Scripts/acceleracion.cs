using UnityEngine;

public class acceleracion : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        rb.AddForce(new Vector3(0, 0, Input.GetAxis("Horizontal")) * speed, ForceMode.Acceleration);

        if (Input.GetAxis("Horizontal") == 0)
        {
            if (rb.linearVelocity.z > 0)
            {
                rb.AddForce(Vector3.back, ForceMode.Acceleration);
            }
            else
            {
                rb.AddForce(Vector3.forward, ForceMode.Acceleration);
            }

            if (Mathf.Approximately(rb.linearVelocity.z, 0.1f))
            {
                rb.linearVelocity = Vector3.zero;
            }
        }
    }
    
}
