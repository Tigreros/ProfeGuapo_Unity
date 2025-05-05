using UnityEngine;

public class InputListener : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            InventoryUIManager.inventoryInstance.ToogleInventory();
        }

        if (InventoryUIManager.inventoryInstance.IsInventoryOpen())
        {
            //if (Input.GetKeyDown(KeyCode.RightArrow)) InventoryUIManager.inventoryInstance.inventoryPanel.transform.GetChild(0).GetComponent<InventoryNavigation>().

        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            GetComponent<VidaFlick>().TakeHit(1f,null);
        }


        if (Input.GetKeyDown(KeyCode.L))
        {
            GetComponent<VidaFlick>().TakeHit(-1f, null);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameStateManager.instance_GameStateManager.ChangeState(GameState.Pausa);
        }








        // ------------------------------------- OTHERS INPUTS ----------------------------------------------- //
        /*
         *  
         * 
         * 
         * 
         * 
         * 
         */
        // ------------------------ oTROS CONTROES COMO ATAUQE, MOVERSE, SCROLL ETC... ---------------------- //
    }
}
