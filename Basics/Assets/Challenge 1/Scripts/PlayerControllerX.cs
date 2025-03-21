using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public float speed;
    public float acceleration;
    public float rotationSpeed;
    public float verticalInput;

    public bool restoreSpeed;

    public float gravity;
    public Vector3 movement;
    public bool encendido;

    public bool stabilizer;

    public float timeCount = 0.0f;
    public float rotX = 0;

    // Start is called before the first frame update
    void Start()
    {
        gravity = 0.1f;
        rotX = transform.eulerAngles.x;
        encendido = true;
        timeCount = 0;
    }

    private void Update()
    {
        if (stabilizer)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, new Quaternion(0, 0, 0, 1), timeCount);
            timeCount += 0.01f * Time.deltaTime;

            if (transform.eulerAngles.x < 3)
            {
                stabilizer = false;
                timeCount = 0;
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // get the user's vertical input
        verticalInput = Input.GetAxis("Vertical");
        rotX = transform.eulerAngles.x; 

        if (encendido)
        {
            movement.y += gravity * Time.deltaTime;
            if(movement.y > 0)
            {
                movement.y = 0;
            }
        }
        else
        {
            movement.y -= gravity * Time.deltaTime;
        }

        // move the plane forward at a constant rate
        transform.Translate(new Vector3(0, movement.y, 1 * speed * acceleration));

        // tilt the plane up/down based on up/down arrow keys
        transform.Rotate(new Vector3(verticalInput,0,0) * rotationSpeed * Time.deltaTime);

        if (restoreSpeed)
        {
            speed += Time.deltaTime * 0.1f;

            if (speed > 0.6)
            { 
                restoreSpeed = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacles"))
        {
            speed = 0.1f;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacles"))
        {
            restoreSpeed = true;
        }
    }
}
