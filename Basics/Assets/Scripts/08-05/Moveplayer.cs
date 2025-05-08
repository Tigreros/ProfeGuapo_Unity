using UnityEngine;

public class Moveplayer : MonoBehaviour
{

    public Rigidbody2D m_Rigidbody2D;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    private Vector3 m_Velocity = Vector3.zero;
    private float m_MovementSmoothing = .05f;

    private int moveDirection;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            if (Input.GetAxis("Horizontal") > 0)
            {
                spriteRenderer.flipX = false;
                moveDirection = -1;
            }
            if (Input.GetAxis("Horizontal") < 0)
            {
                spriteRenderer.flipX = true;
                moveDirection = 1;
            }

            Vector3 targetVelocity = new Vector2(Input.GetAxis("Horizontal") * 10f, m_Rigidbody2D.linearVelocity.y);
            m_Rigidbody2D.linearVelocity = Vector3.SmoothDamp(m_Rigidbody2D.linearVelocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
        }
        else
        {
            moveDirection = 0;
        }

        animator.SetInteger("WalkValue", moveDirection);
    }
}
