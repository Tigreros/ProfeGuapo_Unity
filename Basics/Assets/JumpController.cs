using UnityEngine;

public class JumpController : MonoBehaviour
{
    public Rigidbody rb;
    public int jumpForce;
    Vector3 jumpDireccion;
    public bool isInFloor;
    public int jumpCount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        jumpDireccion = new Vector3(0, jumpForce, 0);
        jumpCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 1)
        {
            rb.AddForce(jumpDireccion, ForceMode.Impulse);
            jumpCount++;
            print(rb.linearVelocity.y);
        }
        else
        {
            if (rb.linearVelocity.y == 0)
            {
                //print("WEA");
                jumpCount = 0;
            }
        }
    }
}
