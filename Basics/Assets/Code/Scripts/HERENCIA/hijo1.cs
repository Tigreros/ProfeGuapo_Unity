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
        base.Accion();  // Llamar a la funci�n del padre
        Debug.Log("Acci�n �nica del Hijo1");
    }
}