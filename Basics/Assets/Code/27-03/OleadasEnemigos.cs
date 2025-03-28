using UnityEngine;
using System.Collections;

public class OleadasEnemigos : MonoBehaviour
{

    public GameObject goblin;
    public GameObject esqueleto;
    public GameObject orco;

    GameObject papa;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        papa = GameObject.Find("Enemigos");

        //StartCoroutine("Oleadas");
    }

    // Update is called once per frame
    void Update()
    {
        if (papa.transform.childCount == 0)
        {
            StartCoroutine("Oleadas");
        }
    }

    public IEnumerator Oleadas()
    {

        for (int i = 0; i < 6; i++)
        {

            GameObject nuevo1 = Instantiate(goblin, papa.transform.position, Quaternion.identity, papa.transform);
            nuevo1.GetComponent<EnemigosScript>().Inicializar("Goblin", Random.Range(80, 100), 1);


            GameObject nuevo2 = Instantiate(esqueleto, papa.transform.position, Quaternion.identity, papa.transform);
            nuevo2.GetComponent<EnemigosScript>().Inicializar("Esqueleto", Random.Range(80,90), 1);

            yield return new WaitForSeconds(Random.Range(1,5));
        }

        GameObject nuevo3 = Instantiate(orco, papa.transform.position, Quaternion.identity, papa.transform);
        nuevo3.GetComponent<EnemigosScript>().Inicializar("Orco", Random.Range(150, 200), 1);

        yield return null;
    }
}