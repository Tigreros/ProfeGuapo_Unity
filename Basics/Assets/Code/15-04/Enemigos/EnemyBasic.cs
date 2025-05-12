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
    public TypeEnemys typeEnemy;

    private bool coolDownActive;

    public bool controlador;

    float stung;

    public IEnumerator coroutine;


    private void OnEnable()
    {
        GameStateManager.OnGameStateChanged += HandleGameState;
        EventBus.HitSusbcribe("HitObject", EventBusTakeHit);
    }

    private void OnDisable()
    {
        GameStateManager.OnGameStateChanged -= HandleGameState;
        EventBus.HitUnsubscribe("HitObject", EventBusTakeHit);
    }

    void EventBusTakeHit(object target, float damage)
    {
        if(target is GameObject go)
        {
            IHitable h = go.GetComponent<IHitable>();
            if(h != null)
            {
                h.TakeHit(damage, null);
            }
            else
            {
                //Debug.Log("DSDAFDFDSAFASFDA12321343214321432154532634576537658759875986FDAf");
            }
        }
    }






    void HandleGameState(GameState state)
    {
        switch (state)
        {
            case GameState.Combate:
                agent.isStopped = true;
                break;

            case GameState.Pausa:
                agent.isStopped = false;
                break;

            case GameState.Recompensa:
                agent.isStopped = false;
                break;
        }
    }



    void Start()
    {
        coroutine = Stung(null);
        currentHealth = maxHealth;
        agent = GetComponent<NavMeshAgent>();
        agent.stoppingDistance = 2;

        GetComponent<CapsuleCollider>().radius = agent.radius;
        GetComponent<CapsuleCollider>().height = agent.height;
        GetComponent<CapsuleCollider>().center = Vector3.up;

        controlador = false;


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

                if (Vector3.Distance(transform.position, enemyTarget.position) < 2 && controlador == false)
                {
                    GameStateManager.instance_GameStateManager.ChangeState(GameState.Combate);
                    EventBus.Publish("OnStartCombat");

                    if (enemyTarget != null)
                    {
                        RaycastHit hit;

                        Debug.DrawRay(transform.position + new Vector3(0, 1, 0), transform.forward * 3, Color.red, 55);


                        if (Physics.Raycast(transform.position + new Vector3 (0,1,0), transform.forward, out hit, 3))
                        {
                            if (hit.collider.CompareTag("Player"))
                            {
                                if (Vector3.Angle(hit.collider.transform.forward, transform.forward) < 50)
                                {
                                    BattleManagerPersistant.instance_BattleManagerPersistant.LoadBattleScene(0, false);

                                    //Debug.Log("Te han atacado por la espalda");
                                }
                                else
                                {
                                    BattleManagerPersistant.instance_BattleManagerPersistant.LoadBattleScene(0, System.Convert.ToBoolean(UnityEngine.Random.Range(0, 2)));
                                    Debug.Log("Cmienza combate por enemigo");
                                }
                            }
                        }
                    }

                    controlador = true;
                }
            }
        }

        if (enemyVision)
        {
            Vision();
        }


    }

    void Die()
    {
        ManagerLog.instance_Log.Log($"{gameObject.name} ha sido derrotado.", "");
        isDied = true;
        enemyHealthBar.SetVisible(false);
        EventBus.Publish("OnEndCombat");
        Destroy(gameObject, 2);
    }

    [ContextMenu("takeHit")]
    public void takehit()
    {
        TakeHit(160, null);
    }


    public void TakeHit(float damage, WeaponData weapon)
    {
        if(weapon != null)
        {
            if (weapon.effectType == StatusEffectType.Freeze && !coolDownActive)
            {
                StartCoroutine(Stung(weapon)); coolDownActive = true;
            }

            if (weapon.effectType == inmunity)
            {
                damage = 0;
                print("El enemigo es inmune a esta arma");
            }
        }

        currentHealth -= damage;





        Debug.Log($"{gameObject.name} recibio {damage} de daño. Vida restante: {currentHealth}");

        enemyHealthBar.UpdateHealth(currentHealth);

        StartCoroutine(VisualTakeHit());

        if (currentHealth <= 0)
        {
            Die();
        }

        CreatePoolVisualDamage.Instance.AssingVisualDamageFunction(this.gameObject, damage);
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

    public void StungCall(float stungTime)
    {
        stung = stungTime;
        StartCoroutine(Stung(null));
    }

    public IEnumerator Stung(WeaponData weapon)
    {

        if (weapon != null)
        {
            switch (typeEnemy)
            {
                case TypeEnemys.Common:
                    break;
                case TypeEnemys.Rare:
                    stung = weapon.stungTime * 0.8f;
                    break;
                case TypeEnemys.Boos:
                    stung = weapon.stungTime * 0.5f;
                    break;
                case TypeEnemys.FinalBoss:
                    stung = weapon.stungTime * 0.2f;
                    break;
            }
        }

        agent.speed = 0;
        transform.GetChild(0).GetComponent<Renderer>().material.color = Color.blue;
        yield return new WaitForSeconds(stung);

        agent.speed = 3.5f;
        transform.GetChild(0).GetComponent<Renderer>().material.color = Color.white;
        yield return new WaitForSeconds(stung * 1.5f);

        coolDownActive = false;
    }




   


}
