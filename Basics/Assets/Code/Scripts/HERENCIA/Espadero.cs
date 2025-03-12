using UnityEngine;

public class Espadero : Unidades
{
    [Header("New variables")]
    public int areaDamage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vida = -100;
        ataque = -200;
        movimiento = -300;
        areaDamage = -400;

        printearTodo();
    }

    // Update is called once per frame
    void Update()
    {

    }

    [ContextMenu("SAFDSAFDSAF")]
    protected override void printearTodo()
    {
        Debug.Log(areaDamage);
    }
}
