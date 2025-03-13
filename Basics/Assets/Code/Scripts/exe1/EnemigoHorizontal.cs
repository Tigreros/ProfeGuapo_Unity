using UnityEngine;

public class EnemigoHorizontal : Enemigo
{
    public Vector3 direction;
    public float limit;

    // Update is called once per frame
    void Update()
    {
        Mover(direction);
        Limite(limit);
    }
}