using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class WeaponUIManager : MonoBehaviour
{
    [Header("WeaponsDatas")]
    public Transform gridParent;
    public GameObject weaponSlotPrefab;
    public WeaponData[] weapons;

    public TextMeshProUGUI titleText;
    public TextMeshProUGUI contentText;
    public Image previewImage;

    private WeaponData current;
    public int index;

    void Start()
    {
        titleText = GameObject.Find("TitleWeapon").GetComponent<TextMeshProUGUI>();
        previewImage = GameObject.Find("PreviewImage").GetComponent<Image>();
        contentText = GameObject.Find("ContentWeapon").GetComponent<TextMeshProUGUI>();


        weaponSlotPrefab = Resources.Load<GameObject>("WeaponSlotPrefab");


        gridParent = GameObject.Find("Inventory").transform;
    }

    [ContextMenu("CACA")]
    public void GetCurrentWeaponData()
    {
        current = weapons[index];
        GameObject slot = Instantiate(weaponSlotPrefab, gridParent);
        slot.transform.GetChild(0).GetComponent<Image>().sprite = current.icon;
        WeaponSlotUI slotUI = slot.GetComponent<WeaponSlotUI>();
        slotUI.Setup(current, this);
        index++;
    }

    internal void WeaponsDetails(WeaponData data)
    {
        current = data;
        titleText.text = data.weaponName;
        previewImage.sprite = data.image;
        contentText.text = $"Daño: {current.damage} \n" + $"Efecto: {current.effectType} \n" + $"Rareza: {current.rarity} \n" + $"Descripción: {current.description} \n";
    }
}
