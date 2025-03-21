using UnityEngine;

public class eJERCICIOcOLISIONES : MonoBehaviour
{
    public float velocitys = 6.0f;
    public float playerSpeed = 1.0f;

    public float fuerzaSaltasion = 6.0f;
    public float boostSalto = 1.0f;
    public float ElNewtons = 9.8f;

    public CharacterController controller;
    private Vector3 direccionMovedura = Vector3.zero;

    public int numJump;
    public int limitJump;
    public bool canDobleJump;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        numJump = 0;
    }

    void Update()
    {
        if (canDobleJump)
        {
            limitJump = 2;
            if (Input.GetButtonDown("Jump"))
            {
                print(numJump + "numjump1");
                numJump++;

                if (numJump < limitJump)
                {
                    print(numJump + "numjump2");
                    direccionMovedura.y = fuerzaSaltasion * boostSalto;
                }
            }
        }
        else
        {
            if (Input.GetButtonDown("Jump") && controller.isGrounded)
            {
                direccionMovedura.y = fuerzaSaltasion * boostSalto ;
            }
        }

        //Activar o desactivar doble salto
        if (Input.GetKeyDown(KeyCode.F1))
        {
            canDobleJump = !canDobleJump;
        }

        if (controller.isGrounded)
        {
            numJump = 0;
        }
    }

    private void FixedUpdate()
    {
        direccionMovedura.y -= ElNewtons * Time.deltaTime;

        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            controller.Move(new Vector3(Input.GetAxis("Horizontal"), direccionMovedura.y, Input.GetAxis("Vertical")) * velocitys * playerSpeed * Time.deltaTime);
        }
    }
}
