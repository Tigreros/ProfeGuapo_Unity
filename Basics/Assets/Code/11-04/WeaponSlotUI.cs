using UnityEngine;
using System;
using UnityEngine.UI;

public class WeaponSlotUI : MonoBehaviour
{

    public Image iconImage;

    public Button button;

    private WeaponData weaponData;
    private WeaponUIManager uiManager;


    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() =>
        {
            uiManager.WeaponsDetails(weaponData);
        });
    }

    public void Setup(WeaponData data, WeaponUIManager manager)
    {
        weaponData = data;
        uiManager = manager;
    }

    /*public void onClick()
    {
        //uiManager.ShowWeaponsDetails(weaponData);
        Debug.Log("He pulsado el boton papa");  
    }*/

    //void OnClick()
    //{
    //    Debug.Log("Clicked!");
    //}
}
