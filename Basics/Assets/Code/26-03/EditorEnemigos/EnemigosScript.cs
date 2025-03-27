using UnityEngine;

public class EnemigosScript : MonoBehaviour
{
    public string nombre;
    public int vida;
    public int dano;

    public void Inicializar(string name, int life, int damage)
    {
        this.nombre = name;
        this.vida = life;
        this.dano = damage;

        Debug.Log($"Enemigo Generado: {nombre} | vida: {vida} | Da�o: {dano}");
    }
}