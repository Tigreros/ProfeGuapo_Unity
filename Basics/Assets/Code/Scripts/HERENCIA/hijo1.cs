using Unity.VisualScripting;
using UnityEngine;

public class Hijo1 : padre
{

    private void Start()
    {
        Accion();
    }

    public override void Accion()
    {
        base.Accion();  // Llamar a la función del padre
        Debug.Log("Acción única del Hijo1");
    }
}