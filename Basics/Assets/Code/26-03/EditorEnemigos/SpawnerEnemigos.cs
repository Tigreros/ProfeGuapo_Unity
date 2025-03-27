using UnityEngine;
using System.IO;

public class SpaawnerEnemigos : MonoBehaviour
{
    string nameEnemy;
    int life;
    int damage;

    public GameObject[] prefabEnemigo;
    GameObject prefabEnemigoElegido;

    [ContextMenu("GenerarEnemigo")]

    public void Spawn()
    {
        string ruta = Path.Combine(Application.streamingAssetsPath, "EnemigosSpawn.json");
        string contenido = File.ReadAllText(ruta);
        EnemigosSpawn datos = JsonUtility.FromJson<EnemigosSpawn>(contenido);

        int EnemigoGenerado = Random.Range(1, 4);
        print(EnemigoGenerado);

            nameEnemy = datos.enemigos[EnemigoGenerado - 1].nombre;
            life = datos.enemigos[EnemigoGenerado - 1].vida;
            damage = datos.enemigos[EnemigoGenerado - 1].dano;
            prefabEnemigoElegido = prefabEnemigo[EnemigoGenerado - 1];


        GameObject papa = GameObject.Find("Enemigos");
        if (EnemigoGenerado == 2)
        {
            GameObject nuevo = Instantiate(prefabEnemigoElegido, papa.transform.position, new Quaternion(-1,0,0,1), papa.transform);
            nuevo.GetComponent<EnemigosScript>().Inicializar(nameEnemy, life, damage);
        }
        else
        {
            GameObject nuevo = Instantiate(prefabEnemigoElegido, papa.transform.position, Quaternion.identity, papa.transform);
            nuevo.GetComponent<EnemigosScript>().Inicializar(nameEnemy, life, damage);
        }
       
        //return prefabEnemigo;
    }
}