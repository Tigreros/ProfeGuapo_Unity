using UnityEngine;

public class Unidades : MonoBehaviour
{

    public int vida;
    public int ataque;
    public int movimiento;

    public void Start()
    {
        printearTodo();
    }

    protected virtual void printearTodo()
    {
        Debug.Log(vida);
        Debug.Log(ataque);
        Debug.Log(movimiento);
        Debug.Log(this.gameObject);
        //pintarConsola();
    }
}
