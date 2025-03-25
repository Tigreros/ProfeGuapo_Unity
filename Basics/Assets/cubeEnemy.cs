using UnityEngine;


public class cubeEnemy : MonoBehaviour
{

    LectorJsonAnidado lector;

    [ContextMenu("CACA")]
    void EnemigoLlamada()
    {
        lector = GameObject.Find("Directional Light").GetComponent<LectorJsonAnidado>();
        Debug.Log(lector.pj.stats.vida.porcentaje);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
