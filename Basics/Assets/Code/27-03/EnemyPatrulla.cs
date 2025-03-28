using System.Collections;
using UnityEngine;

public class EnemyPatrulla : MonoBehaviour
{

    public GameObject[] posFinal;
    public float paso;
    public float pausa;

    public float proximity;

    public Vector3 direccion;
    public Vector3 posInicial;
    public Vector3 vectorB;

    public bool isForward;

    int i;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        posInicial = transform.position;
        paso = 0.01f;
        pausa = 3;
        proximity = 0.5f;
        posFinal = GameObject.FindGameObjectsWithTag("Objetivos");
        isForward = true;

        vectorB = posFinal[i].transform.position;

        StartCoroutine("PatrullaEnemy");
    }

    IEnumerator PatrullaEnemy()
    {
        while(Vector3.Distance(transform.position, vectorB) > proximity)
        {
            direccion = (vectorB - transform.position).normalized;
            transform.Translate(direccion);
            yield return new WaitForSeconds(paso);
        }

        Debug.Log("Enemigo llego al objetivo");

        yield return new WaitForSeconds(pausa);
        i++;

        if (i >= posFinal.Length)
        {
            isForward = !isForward;
        }
        else
        {
            isForward = true;
        }
        
        if (isForward) { vectorB = posFinal[i].transform.position; }
        else{ vectorB = posInicial; i = -1; }

        proximity = Random.Range(0.5f, 4f);

        StartCoroutine("PatrullaEnemy");
    }

}
