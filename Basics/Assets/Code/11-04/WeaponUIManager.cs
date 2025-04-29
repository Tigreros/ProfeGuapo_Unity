using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;


public class WeaponUIManager : MonoBehaviour
{
    public static WeaponUIManager instance_WeaponManager
    { get; private set; }

    [Header("WeaponsDatas")]
    public Transform gridParent;
    public GameObject weaponSlotPrefab;
    public List<WeaponData> weapons = new List<WeaponData>();

    public List<WeaponData> selectWeapons = new List<WeaponData>();

    public List<GameObject> slot = new List<GameObject>();

    public TextMeshProUGUI titleText;
    public TextMeshProUGUI contentText;
    public Image previewImage;

    private WeaponData current;
    public int index;

    public Button fusionButton;

    public WeaponInventory inventory;





    /*private void OnEnable()
    {
        GameStateManager.OnGameStateChanged += HandleGameState;
    }

    private void OnDisable()
    {
        GameStateManager.OnGameStateChanged -= HandleGameState;
    }
    void HandleGameState(GameState state)
    {
        switch (state)
        {
            case GameState.Combate:
                rotateSpeed = 0;
                break;

            case GameState.Pausa:
                speed = 0;
                break;

            case GameState.Recompensa:
                speed = 0;
                break;
        }
    }*/


    private void Awake()
    {
        if (instance_WeaponManager != null && instance_WeaponManager != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance_WeaponManager = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    void Start()
    {
        titleText = GameObject.Find("TitleWeapon").GetComponent<TextMeshProUGUI>();
        previewImage = GameObject.Find("PreviewImage").GetComponent<Image>();
        contentText = GameObject.Find("ContentWeapon").GetComponent<TextMeshProUGUI>();

        weaponSlotPrefab = Resources.Load<GameObject>("WeaponSlotPrefab");

        gridParent = GameObject.Find("Inventory").transform;
        gridParent.gameObject.SetActive(false);


        fusionButton = GameObject.Find("Fusion").GetComponent<Button>();
        fusionButton.onClick.AddListener(AttemptFusion);

        inventory = GameObject.Find("Flick").GetComponent<WeaponInventory>();
    }

    public void GetCurrentWeaponData(WeaponData data)
    {
        Debug.Log(data);
        weapons.Add(data);
        slot.Add(Instantiate(weaponSlotPrefab, gridParent));
        slot[slot.Count - 1].transform.GetChild(0).GetComponent<Image>().sprite = data.icon;
        WeaponSlotUI slotUI = slot[slot.Count - 1].GetComponent<WeaponSlotUI>();
        slotUI.Setup(data, this);
    }

    internal void WeaponsDetails(WeaponData data)
    {
        current = data;
        titleText.text = data.weaponName;
        previewImage.sprite = data.image;
        contentText.text = $"Daño: {current.damage} \n" + $"Efecto: {current.effectType} \n" + $"Rareza: {current.rarity} \n" + $"Descripción: {current.description} \n";
    }

    public void RemoveWeaponUpgrade(WeaponData weaponRemove)
    {
        for (int i = 0; i < weapons.Count; i++)
        {
            if (weapons[i] == weaponRemove)
            {
                weapons.RemoveAt(i);
                Destroy(slot[i]);
                slot.RemoveAt(i);
                break;
            }
        }
    }


    public void SelectWeaponForFusion(WeaponData data)
    {
        //if (selectWeapons.Contains(data)) return;

        if (selectWeapons.Count <= 1) 
        {
            selectWeapons.Add(data);
            data.isSelected = true;
        }

        if (selectWeapons.Count >= 2)
        {
            ManagerLog.instance_Log.Log("YA TENEMOS DOS ARMAS SELECCIONADAS", "");
        }

        ManagerLog.instance_Log.Log($" Seleccionaste: {data.weaponName}", "");
    }


    private void AttemptFusion()
    {
        if(selectWeapons.Count != 2)
        {
            ManagerLog.instance_Log.Log("Selecciona exactamente dos armas para fusionar.", "");
            return;
        }

        WeaponData a = selectWeapons[0];
        WeaponData b = selectWeapons[1];

        if(a.weaponName == b.weaponName)
        {
            WeaponData fused = a.CloneAndUpgrade();
            fused.isSelected = false;
            inventory.AddWeapon(fused);
            ManagerLog.instance_Log.Log($"Fusión exitosa! Creaste: {fused.weaponName}", "fused");

            RemoveWeaponUpgrade(a);
            RemoveWeaponUpgrade(b);
        }
        else
        {
            ManagerLog.instance_Log.Log($"NO SE PUEDEN fusionar cosas distintas: {a.weaponName} y {b.weaponName}", "");
        }

        selectWeapons.Clear();
    }
}
