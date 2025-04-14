using UnityEngine;
using System;
using UnityEngine.UI;

public class WeaponSlotUI : MonoBehaviour
{

    public Image iconImage;

    public Button button;
    public Button buttonSelect;

    public WeaponData weaponData;
    public WeaponUIManager uiManager;


    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() =>
        {
            uiManager.WeaponsDetails(weaponData);
        });

        buttonSelect = transform.GetChild(1).GetComponent<Button>();
        buttonSelect.onClick.AddListener(() =>
        {
            uiManager.SelectWeaponForFusion(weaponData);

        });
    }

    public void Setup(WeaponData data, WeaponUIManager manager)
    {
        weaponData = data;
        uiManager = manager;
    }
}
