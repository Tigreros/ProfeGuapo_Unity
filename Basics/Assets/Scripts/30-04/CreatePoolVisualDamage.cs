using UnityEngine;

public class CreatePoolVisualDamage : MonoBehaviour
{

    public static CreatePoolVisualDamage Instance { get; private set; }

    public GameObject[] visualDamages;
    public int cantidadPool = 15;

    public int index;


    public void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); return;
        }
        
        Instance = this;

        //DontDestroyOnLoad(this);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        visualDamages = new GameObject[cantidadPool];

        for (int i = 0; i < cantidadPool; i++)
        {
            GameObject instance = Instantiate(Resources.Load("VisualDamage") as GameObject, Vector3.zero, Quaternion.identity, this.gameObject.transform);
            instance.GetComponent<Canvas>().enabled = false;
            visualDamages[i] = instance;
        }
    }

    public void AssingVisualDamageFunction(GameObject target, float damage)
    {
        visualDamages[index].GetComponent<VisualDamage>().VisualDamageFunction(target, damage);
        
        index++;

        if (index > visualDamages.Length - 1)
        {
            index = 0;
        }
    }
}
