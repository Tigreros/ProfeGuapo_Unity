using System.IO;
using UnityEngine;

public class SpawnerEnemys : MonoBehaviour
{

    public GameObject[] prefabGoblin;

    public GameObject[] prefabGoblinCreated;

    public Vector3[] prefabGoblinPosition;

    public int poolSize;
    public int x; 
    public int w;

    public string ruta;

    void Start()
    {
        x = 0;
        prefabGoblinCreated = new GameObject[poolSize];

        LoadPosition();
    }

    private void CreateEnemy()
    {
        for (int i = 0; i < poolSize; i++)
        {
            if (x < 5) { w = 0; }
            if (x >= 5 && x < 9) { w = 1; }
            if (x == 9) { w = 2; }

            GameObject enemy = Instantiate(prefabGoblin[w], this.transform);
            prefabGoblinCreated[i] = enemy;

            x++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            prefabGoblinPosition = new Vector3[prefabGoblinCreated.Length];

            for (int i = 0; i < prefabGoblinCreated.Length; i++) 
            {
                prefabGoblinPosition[i] = prefabGoblinCreated[i].transform.position;
            }

            SavePosition();
        }
    }


    public void SavePosition()
    {
        print("SAVE LLAMAO");
        for (int i = 0; i < prefabGoblinCreated.Length; i++)
        {
            SpawnerEnemyPositionData datos = new SpawnerEnemyPositionData();

            datos.x = prefabGoblinPosition[i].x;
            datos.y = prefabGoblinPosition[i].y;
            datos.z = prefabGoblinPosition[i].z;

            string json = JsonUtility.ToJson(datos, true);

            Directory.CreateDirectory(Path.Combine(Application.persistentDataPath, "SpawnerEnemys"));

            ruta = Path.Combine(Application.persistentDataPath,"SpawnerEnemys",i.ToString() + "pos.json");

            File.WriteAllText(ruta, json);
        }
    }

    public void LoadPosition()
    {
        if (File.Exists(Path.Combine(Application.persistentDataPath, "SpawnerEnemys", "0pos.json")))
        {

            print("Exsiten datos guardaos wey");
            CreateEnemy();
            for (int i = 0; i < prefabGoblinCreated.Length; i++)
            {
                string contenido = File.ReadAllText(Path.Combine(Application.persistentDataPath, "SpawnerEnemys", i.ToString() + "pos.json"));
                prefabGoblinCreated[i].transform.position =
                    new Vector3(
                        JsonUtility.FromJson<SpawnerEnemyPositionData>(contenido).x,
                        JsonUtility.FromJson<SpawnerEnemyPositionData>(contenido).y,
                        JsonUtility.FromJson<SpawnerEnemyPositionData>(contenido).z
                    );
            }

            //for (int i = 0; i < prefabGoblinCreated.Length; i++)
            //{
            //    File.Delete(Path.Combine(Application.persistentDataPath, "SpawnerEnemys", i.ToString() + "pos.json"));
            //}
        }
        else
        {
            CreateEnemy();
            print("NO Exsiten datos guardaos");
            return;
        }
    }
}
