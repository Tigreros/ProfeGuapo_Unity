using UnityEngine;

public class EnemigosScript : MonoBehaviour
{
    public string nombre;
    public float vida;
    public int dano;

    public void Inicializar(string name, int life, int damage)
    {
        this.nombre = name;
        this.vida = life;
        this.dano = damage;

        Debug.Log($"Enemigo Generado: {nombre} | vida: {vida} | Da�o: {dano}");
    }

    private void Update()
    {
        vida = vida - 5 * Time.deltaTime;

        if (vida <= 0)
        {
            Destroy(this.gameObject);
        }

    }
}