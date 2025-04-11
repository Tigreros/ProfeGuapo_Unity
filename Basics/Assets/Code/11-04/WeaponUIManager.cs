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

    public List<GameObject> slot = new List<GameObject>();

    public TextMeshProUGUI titleText;
    public TextMeshProUGUI contentText;
    public Image previewImage;

    private WeaponData current;
    public int index;


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
    }

    public void GetCurrentWeaponData(WeaponData data)
    {
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

    public void RemoveWeaponUpgrade()
    {
        weapons.RemoveAt(weapons.Count - 1);
        Destroy(slot[slot.Count - 1]);
    }
}
