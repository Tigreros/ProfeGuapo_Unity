using UnityEngine;

public class Moveplayer : MonoBehaviour
{

    public Rigidbody2D m_Rigidbody2D;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public Transform t_groundChecker;
    public LayerMask m_WhatIsGround;
    public bool m_IsGround;

    private Vector3 m_Velocity = Vector3.zero;
    private float m_MovementSmoothing = .05f;

    private int moveDirection;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        t_groundChecker = transform.GetChild(0);
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



        if (Input.GetButtonDown("Jump"))
        {
            m_Rigidbody2D.AddForce(new Vector2(0f, 400f));
        }

        Collider2D[] colliders = Physics2D.OverlapCircleAll(t_groundChecker.position, 0.2f, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                animator.SetBool("Jump", false);
                m_IsGround = true;
            }
        }

        if(colliders.Length == 0)
        {
            animator.SetBool("Jump", true);
            m_IsGround = false;
        }


    }
}
