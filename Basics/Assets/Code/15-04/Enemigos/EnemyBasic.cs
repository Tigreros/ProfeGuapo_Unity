using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(EnemyHealthBar))]
public class EnemyBasic : MonoBehaviour, IHitable
{

    public float maxHealth = 50;
    public float currentHealth;

    public NavMeshAgent agent;
    public Transform enemyTarget;

    public Transform player;
    public Camera camara;

    public Material material;

    public bool isDied;

    public bool enemyVision;

    public float distance;
    public float angle;
    public float visionAngle;
    public float detectionRange;

    public GameObject enemyCanvas;
    private GameObject prefab;

    public EnemyHealthBar enemyHealthBar;

    public StatusEffectType inmunity;


    void Start()
    {
        currentHealth = maxHealth;
        agent = GetComponent<NavMeshAgent>();
        agent.stoppingDistance = 2;

        GetComponent<CapsuleCollider>().radius = agent.radius;
        GetComponent<CapsuleCollider>().height = agent.height;
        GetComponent<CapsuleCollider>().center = Vector3.up;




        prefab = Resources.Load("EnemyCanvas") as GameObject;

        enemyCanvas = Instantiate(prefab, new Vector3(transform.position.x,transform.position.y + agent.height + 0.25f,transform.position.z), Quaternion.identity, this.transform);
        enemyHealthBar = GetComponent<EnemyHealthBar>();

        GetComponent<EnemyHealthBar>().canvas = enemyCanvas.GetComponent<Canvas>();
        GetComponent<EnemyHealthBar>().healthSlider = enemyCanvas.transform.GetChild(0).GetComponent<Slider>();
        enemyHealthBar.Setup(maxHealth);
        enemyHealthBar.SetVisible(false);


        player = GameObject.FindWithTag("Player").transform;
        camara = player.GetComponentInChildren<Camera>();

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

    void IHitable.TakeHit(float damage, WeaponData weapon)
    {
        if (weapon.effectType == inmunity)
        {
            damage = 0;
            print("El enemigo es inmune a esta arma");
        }
        else
        {
            currentHealth -= damage;
            Debug.Log($"{gameObject.name} recibio {damage} de daño. Vida restante: {currentHealth}");

            enemyHealthBar.UpdateHealth(currentHealth);

            StartCoroutine(VisualTakeHit());

            if (currentHealth <= 0)
            {
                Die();
            }
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
                        enemyHealthBar.SetVisible(true);
                        enemyHealthBar.FollowCamera(camara.transform);
                    }
                    else
                    {
                        print($"Esta colisionando contra otra cosa {hit.collider.name}");
                    }
                }
            }
        }
    }

    void Die()
    {
        ManagerLog.instance_Log.Log($"{gameObject.name} ha sido derrotado.", "");
        isDied = true;
        enemyHealthBar.SetVisible(false);
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
