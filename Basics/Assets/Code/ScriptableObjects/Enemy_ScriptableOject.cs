using UnityEngine;

public class Enemy_ScriptableOject : MonoBehaviour
{
    public EnemyData data;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("mi vida es: " + data.health);
    }

    private void Update()
    {
        if (data.health > 0)
        {
            Debug.Log("mi vida esta vivo");
        }
    }
}
