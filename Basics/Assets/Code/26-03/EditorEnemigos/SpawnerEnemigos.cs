using UnityEngine;

public class SpawnerEnemigos : MonoBehaviour
{
    public GameObject prefabEnemigo;

    [ContextMenu("SpawnEnemy")]
    public void Spawn()
    {


        GameObject papa = GameObject.Find("Enemigos");

        GameObject nuevo = Instantiate(prefabEnemigo, papa.transform.position, Quaternion.identity, papa.transform);
        nuevo.GetComponent<Enemigo>().Inicializar("Alón",4,89); 
    }
}
