using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBasic : MonoBehaviour, IHitable
{

    public float maxHealth = 50;
    public float currentHealth;

    public NavMeshAgent agent;
    public Transform enemyTarget;

    public Transform player;

    public Material material;

    public bool isDied;

    public bool enemyVision;

    public float distance;
    public float angle;
    public float visionAngle;
    public float detectionRange;


    void Start()
    {
        currentHealth = maxHealth;
        agent = GetComponent<NavMeshAgent>();

        player = GameObject.FindWithTag("Player").transform;

        if (!enemyVision)
        {
            enemyTarget = GameObject.FindWithTag("Player").transform;
        }

        material = GetComponentInChildren<SkinnedMeshRenderer>().material;
    }

    void Update()
    {
        if (!isDied)
        {
            if (enemyTarget != null)
            {
                agent.SetDestination(enemyTarget.position);
            }
        }
        if (enemyVision)
        {
            Vision();
        }
    }

    void IHitable.TakeHit(float damage)
    {
        currentHealth -= damage;
        Debug.Log($"{gameObject.name} recibio {damage} de daño. Vida restante: {currentHealth}");

        StartCoroutine(VisualTakeHit());

        if(currentHealth <= 0) 
        {
            Die();
        }
    }

    public void Vision()
    {
        Vector3 dirToPlayer = player.position - transform.position;
        distance = dirToPlayer.magnitude;
        angle = Vector3.Angle(transform.forward, dirToPlayer);
        RaycastHit hit;

        if (distance < detectionRange) 
        { 
            if(angle < visionAngle)
            {
                if (Physics.Raycast(transform.position + new Vector3(0, 1, 0), dirToPlayer, out hit, detectionRange))
                {
                    if (hit.collider.CompareTag("Player"))
                    {
                        enemyTarget = player;
                    }
                }
            }
        }
    }

    void Die()
    {
        ManagerLog.instance_Log.Log($"{gameObject.name} ha sido derrotado.", "");
        isDied = true;
        Destroy(gameObject,2);
    }

    IEnumerator VisualTakeHit()
    {
        material.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        if (isDied)
        {
            material.color = Color.black;
        }
        else
        {
            material.color = Color.white;
        }
    }
}
