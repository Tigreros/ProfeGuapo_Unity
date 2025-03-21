using UnityEngine;


public class movimiento : MonoBehaviour
{

    public float speedX; 
    public float speedY;

    public bool isHorizontal;

    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.position += new Vector3(speedX, speedY, 0);
    }


    // Memory creando una funcion: Horizontal.Move(); Pesara 100MB
    // Memory creando una funcion: Vertical.Move(); Pesara 100MB
    // 200MB
}
