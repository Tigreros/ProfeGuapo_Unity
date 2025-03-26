using UnityEngine;

public class Enemigo : MonoBehaviour
{

    public string nombre;
    public int vida;
    public int dano;

    public void Inicializar(string name, int life, int damage)
    {
        this.nombre = name;
        this.vida = life;
        this.dano = damage;

        Debug.Log($"Enemigo creado: {nombre} | Vida : {vida} | Daño: {dano}");
    }
}
