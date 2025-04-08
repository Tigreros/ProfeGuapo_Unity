using System;
using JetBrains.Annotations;
using UnityEngine;

public class Enemy_ScriptableOject : MonoBehaviour, IHitable
{
    public EnemyData data;

    private float currentHealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = data.health;
        Debug.Log(currentHealth);
    }

    private void Update()
    {

    }

    public void TakeHit(float damage)
    {
        currentHealth -= damage;
        Debug.Log(currentHealth);

        if (currentHealth <= 0)
        {
            Debug.Log("Se murio el " + gameObject.name);
            Destroy(gameObject,1);
        }
    }
}
