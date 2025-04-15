using UnityEngine;
using System;
using UnityEngine.UI;
using Unity.VisualScripting;

public class WeaponSlotUI : MonoBehaviour
{

    public Image iconImage;

    public Button button;
    //public GameObject go_Toggle;
    public Button buttonSelect;

    public WeaponData weaponData;
    public WeaponUIManager uiManager;


    private void Start()
    {
        //go_Toggle = GetComponentInChildren<Toggle>().gameObject;

        button = GetComponent<Button>();

        button.onClick.AddListener(() =>
        {
            uiManager.WeaponsDetails(weaponData);
        });

        buttonSelect = transform.GetChild(2).GetComponent<Button>();

        buttonSelect.onClick.AddListener(() =>
        {
            uiManager.SelectWeaponForFusion(weaponData);
            //go_Toggle.GetComponent<togglePrefabSlots>().FlipFlop();
        });
    }

    public void Setup(WeaponData data, WeaponUIManager manager)
    {
        weaponData = data;
        uiManager = manager;
    }
}
