using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class InventoryNavigation : MonoBehaviour
{
    public List<GameObject> slotVisuals;
    public int columns;
    private int index = 0;

    void Start()
    {
        columns = GetComponent<GridLayoutGroup>().constraintCount;
        //FindChildren();
        HighlightSlot(index);
    }

    void Update()
    {

        slotVisuals = WeaponUIManager.instance_WeaponManager.slot;

        if (!InventoryUIManager.inventoryInstance.IsInventoryOpen()) return;

        int prevIndex = index;

        if (Input.GetKeyUp(KeyCode.RightArrow)) index++;
        if (Input.GetKeyUp(KeyCode.LeftArrow)) index--;
        if (Input.GetKeyUp(KeyCode.UpArrow)) index -= columns;
        if (Input.GetKeyUp(KeyCode.DownArrow)) index += columns;

        if (Input.GetKeyUp(KeyCode.D)) index++;
        if (Input.GetKeyUp(KeyCode.A)) index--;
        if (Input.GetKeyUp(KeyCode.W)) index -= columns;
        if (Input.GetKeyUp(KeyCode.S)) index += columns;

        if (index >= slotVisuals.Count) index = 0;
        if (index < 0) index = slotVisuals.Count - 1;

        if (prevIndex != index)
        {
            HighlightSlot(index);
        }

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            //slotVisuals[index].GetComponent<TEXTOTOGUAPO>().stringear();
            slotVisuals[index].GetComponent<WeaponSlotUI>().ShowWeaponsDetails();
        }
        // WeaponSlotUI.OnSelect();
    }

    public void FindChildren()
    {
        int childCount = transform.childCount;

        for (int i = 0; i < childCount; i++)
        {
            slotVisuals.Add(transform.GetChild(i).gameObject);
        }
    }


    void HighlightSlot(int newIndex)
    {
        // Aplicar la logica de cual de todos esta seleccionado y aplicarle un color, un brde, o una wea

        for (int i = 0; i < slotVisuals.Count; i++)
        {
            Image img = slotVisuals[i].GetComponent<Image>();

            img.color = (i == newIndex) ? Color.red : Color.white;

            //if(i == newIndex)
            //{
            //    img.color = Color.red;
            //}
            //else
            //{
            //    img.color =  Color.green;
            //}
        }
    }
}
