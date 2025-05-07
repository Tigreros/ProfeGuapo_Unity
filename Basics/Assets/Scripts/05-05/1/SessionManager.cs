using UnityEngine;
using System.IO;
using System.Linq;

public class SessionManager : MonoBehaviour
{
    public static SessionManager instance_SessionManager { get; private set; }
    private string path;
    private PlayerSessionData session;
    public string nameUser;

    public WeaponData[] baseReferences;


    private void Awake()
    {
        if (instance_SessionManager != null && instance_SessionManager != this)
        {
            Destroy(this); return;
        }
        
        instance_SessionManager = this;
        DontDestroyOnLoad(this);

        LoadSession();
    }

    public void ChangeUserName(string newUserName)
    {
        nameUser = newUserName;
    }

    public void SaveSession()
    {
        session.playerName = nameUser;
        path = Application.persistentDataPath + $"/{session.playerName}_session.json";

        string json = JsonUtility.ToJson(session, true);
        File.WriteAllText(path, json);
        Debug.Log("Sesion guardada en la ruta: " + path);
    }

    public void LoadSession()
    {
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            session = JsonUtility.FromJson<PlayerSessionData>(json);
            Debug.Log("Sesion cargada: " + session.playerName);
        }
        else
        {
            session = new PlayerSessionData();
            session.deviceID = SystemInfo.deviceUniqueIdentifier;
            session.musicVolume = 1f;
            session.sfxVolume = 1f;
        }
    }







    [ContextMenu("SAVE")]
    public void SaveInventory()
    {
        WeaponInventory inventory = GameObject.Find("Flick").GetComponent<WeaponInventory>();

        InventorySaveData data = new InventorySaveData();

        foreach (var w in inventory.inventory)
        {
            data.inventory.Add(WeaponSerializer.ToSaveData(w));
        }

        if(inventory.equippedWeapon != null)
        {
            data.equippedWeapon = WeaponSerializer.ToSaveData(inventory.equippedWeapon);
        }

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(Application.persistentDataPath + $"/{session.playerName}_inventory.json", json);
    }





    [ContextMenu("LOAD")]
    public void LoadInventory()
    {
        WeaponInventory inventory = GameObject.Find("Flick").GetComponent<WeaponInventory>();
        string path = Application.persistentDataPath + "/_inventory.json";

        if (!File.Exists(path)) return;

        string json = File.ReadAllText(path);
        InventorySaveData data = JsonUtility.FromJson<InventorySaveData>(json);

        inventory.inventory.Clear();

        foreach (var saved in data.inventory)
        {
            WeaponData clone = WeaponSerializer.ToWeaponData(saved, baseReferences[0]);

            inventory.inventory.Add(clone);
            inventory.AddWeapon(clone);

            print(saved);
        }

        if(data.equippedWeapon != null)
        {
            inventory.equippedWeapon = WeaponSerializer.ToWeaponData(data.equippedWeapon, baseReferences[0]);
        }
    }



    public void FastSave()
    {
        WeaponInventory inventory = GameObject.Find("Flick").GetComponent<WeaponInventory>();

        InventorySaveData data = new InventorySaveData();

        foreach (var w in inventory.inventory)
        {
            data.inventory.Add(WeaponSerializer.ToSaveData(w));
        }

        if (inventory.equippedWeapon != null)
        {
            data.equippedWeapon = WeaponSerializer.ToSaveData(inventory.equippedWeapon);
        }

        string json = JsonUtility.ToJson(data, true);
        string path = Application.temporaryCachePath + $"/{session.playerName}_inventory.json";
        File.WriteAllText(path, json);

        Debug.Log("Sesion guardada en la ruta: " + path);
    }
}
