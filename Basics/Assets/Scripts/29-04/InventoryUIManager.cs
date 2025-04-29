using UnityEngine;

public class InventoryUIManager : MonoBehaviour
{

    public static InventoryUIManager inventoryInstance 
    { get; private set; }

    public GameObject inventoryPanel;
    private bool isOpen;

    private void Awake()
    {
        if (inventoryInstance != null && inventoryInstance != this)
        {
            Destroy(gameObject); return;
        }

        inventoryInstance = this;

        inventoryPanel = GameObject.Find("PanelInventario");
        inventoryPanel.SetActive(false);

        DontDestroyOnLoad(this);
    }

    public void ToogleInventory()
    {
        isOpen = !isOpen;
        inventoryPanel.SetActive(isOpen);

        if (isOpen)
        {
            GameStateManager.instance_GameStateManager.ChangeState(GameState.inventario);
        }

        else
        {

            GameStateManager.instance_GameStateManager.ChangeState(GameState.EnJuego);

            // ----------------------------------  Esto debemos ampliarlo con un switch -------------------------------------- // 
            /*
             * 
             * 
             * 
             * 
             */
            // ----------------------------------  Esto debemos ampliarlo con un switch -------------------------------------- // 
        }

        EventBus.Publish("OnInventoryToggle");
        // ----------------------------------  Este apartado nos srve para animaciones, logs, sonidos -------------------------------------- // 
    }

    public bool IsInventoryOpen() => isOpen;

}
