using UnityEngine;
using System.IO;

public class SessionManager : MonoBehaviour
{
    public static SessionManager instance_SessionManager { get; private set; }
    private string path;
    private PlayerSessionData session;
    public string nameUser;

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







}
