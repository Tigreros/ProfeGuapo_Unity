using System.Collections;
using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{

    public GameObject[] prefab;
    public int countMax;

    private GameObject[] enemyInScene;
    private int count;

    void Start()
    {
        enemyInScene = new GameObject[countMax];
        prefab = new GameObject[] { Resources.Load<GameObject>("patrick_skeleton_m"), Resources.Load<GameObject>("goblin kamikaze") };
        StartCoroutine("SpawnerTime");
    }

    void Update()
    {
        count = transform.childCount;
    }

   IEnumerator SpawnerTime()
    {
        yield return new WaitForSeconds(1);

        if (count < countMax)
        {
            enemyInScene[count] = 
                Instantiate(
                    prefab[Random.Range(0, 2)], 
                    transform.position + new Vector3(Random.Range(1, 3.0f),transform.position.y,Random.Range(1, 3.0f)), 
                    transform.rotation, 
                    this.transform
                    );
        }

        StartCoroutine("SpawnerTime");
    }
}
