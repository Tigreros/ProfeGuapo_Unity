using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    public GameObject plane;
    public Vector3 offset;

    public bool isDeath;

    // Start is called before the first frame update
    void Start()
    {
        plane = GameObject.Find("Player");

        BotonDelegado.OnBotonPresionado += Death;
        BotonDelegado.OnBotonPresionado += Death1;
        BotonDelegado.OnBotonPresionado += Death2;
        BotonDelegado.OnBotonPresionado += Death3;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDeath)
        {
            transform.position = plane.transform.position + offset;
        }
    }

    void Death()
    {
        isDeath = true;
    }
    void Death1()
    {
        Debug.Log("Death1");
    }
    void Death2()
    {
        Debug.Log("Death2");
    }
    void Death3()
    {
        Debug.Log("Death3");
    }
}
