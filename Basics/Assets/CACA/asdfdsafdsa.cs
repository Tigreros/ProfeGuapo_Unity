using UnityEngine;

public class asdfdsafdsa : MonoBehaviour
{
public float velocitys = 6.0f;
public float fuerzaSaltasion = 6.0f;
public float ElNewtons = 20.0f;

private CharacterController controller;
private Vector3 direccionMovedura = Vector3.zero;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (controller.isGrounded)
        {
        direccionMovedura = new
        Vector3(Input.GetAxis("Horizontal"), 0, 0) * velocitys;
        }

        if (Input.GetButton("Jump"))
        {
        direccionMovedura.y = fuerzaSaltasion;
        }
    }

        private void FixedUpdate()
        {
            direccionMovedura.y -= ElNewtons * Time.deltaTime;
            controller.Move(direccionMovedura * Time.deltaTime);
        }
    }
