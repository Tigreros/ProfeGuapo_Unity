using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CharacterController))]
public class CC_Move : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    public float playerSpeed = 2.0f;
    public float jumpHeight = 2.0f;
    private float gravityValue = -9.81f;

    [Header("DASH")]
    public float dashForce = 15;
    public float dashDuration = 0.3f;
    public float dashTime = 0.0f;
    public bool isDash;
    public bool isSecondDash;
    public int numDash;

    public float coolDownTime = 0.0f;
    public float coolDownCurrent = 5.0f;
    private bool isCoolDown;


    private float sprint = 1.0f;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        controller.minMoveDistance = 0;
        controller.skinWidth = 0.001f;
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;

        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));










        // Este es el segundo dash
        if (Input.GetKeyDown(KeyCode.E) && isDash && isCoolDown && numDash < 2)
        {
            dashTime = dashDuration;
            coolDownTime = coolDownCurrent;
            isSecondDash = true;
            numDash++;

            print("EL Segundo DASH");
        }

        // El primero Activar dash
        if (Input.GetKeyDown(KeyCode.E) && !isDash && !isCoolDown && numDash < 2)
        {
            dashTime = dashDuration;
            coolDownTime = coolDownCurrent;
            isDash = true;
            isCoolDown = true;
            numDash++;

            print("EL primer DASH");
        }




        if (Input.GetKey(KeyCode.Q))
        {
            sprint = 1.3f;
        }
        else
        {
            sprint = 1;
        }

        // Aplicar dash con Lerp
        if (isDash)
        {
            if (!isSecondDash)
            {
                // Interpolamos entre la velocidad normal y la velocidad de dash
                float dashSpeed = Mathf.Lerp(playerSpeed, playerSpeed * dashForce, 1 - (dashTime / dashDuration));

                move.x *= dashSpeed / playerSpeed;
                move.z *= dashSpeed / playerSpeed;

                dashTime -= Time.deltaTime;

                if (dashTime <= 0 )
                {
                    isDash = false;
                    numDash = 0;
                }
            }
            else
            {
                // Interpolamos entre la velocidad normal y la velocidad de dash
                float dashSpeed = Mathf.Lerp(playerSpeed, playerSpeed * dashForce, 1 - (dashTime / dashDuration));

                move.x *= (dashSpeed / playerSpeed) * 2;
                move.z *= (dashSpeed / playerSpeed) * 2;

                dashTime -= Time.deltaTime;

                if (dashTime <= 0)
                {
                    isDash = false;
                    isSecondDash = false;
                    numDash = 0;
                }
            }
        }

        // Control de cooldown
        if (isCoolDown)
        {
            coolDownTime -= Time.deltaTime;

            if (coolDownTime <= 0)
            {
                isCoolDown = false;
            }
        }

        // Movimiento normal del jugador
        controller.Move(move * Time.deltaTime * playerSpeed * sprint);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        // Salto
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -1 * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;

        // Aplicar la gravedad
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
