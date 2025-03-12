using UnityEngine;

public class Arquero : Unidades
{
    [Header("New variables")]
    public int alcance;
    public int reload;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vida = 150;
        ataque = 250;
        movimiento = 350;
        alcance = 450;
        reload = 550;

        printearTodo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [ContextMenu("SAFDSAFDSAF")]
    protected override void printearTodo()
    {
        base.printearTodo();
        Debug.Log(alcance);
        Debug.Log(reload);
    }
}
