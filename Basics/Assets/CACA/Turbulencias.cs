using System.Threading;
using Unity.Hierarchy;
using UnityEngine;

public class Turbulencias : MonoBehaviour
{

    Rigidbody m_Rigidbody;
    public float turbulencias = 10;
    public float timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        timer = Random.Range(5.0f, 20.0f);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            TurbulenciasFunction();
            timer = Random.Range(5.0f, 20.0f);
        }
    }

    public void TurbulenciasFunction()
    {
        float randomFloat = Random.Range(-turbulencias, turbulencias);

        m_Rigidbody.AddForce(new Vector3(0, randomFloat, 0), ForceMode.Impulse);
        //print("La turulencia " + randomFloat);
    }
}
