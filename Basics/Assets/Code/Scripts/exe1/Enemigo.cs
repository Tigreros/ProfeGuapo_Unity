using Unity.VisualScripting;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    protected float velocidad;

    private void Start()
    {
        velocidad = 1;
    }
    protected void Mover(Vector3 direccion)
    {
        transform.Translate(direccion * velocidad * Time.deltaTime);
    }

    protected void Limite(float limite)
    {
        if (Mathf.Abs(transform.position.z) > limite || Mathf.Abs(transform.position.y) > limite)
        {
            velocidad = velocidad * -1;
        }
    }
}
