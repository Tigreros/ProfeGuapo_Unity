using UnityEngine;
using UnityEngine.UI;

public class PauseMenuSaveData : MonoBehaviour
{

    public Button buttonSelect;

    public void OnEnable()
    {
        buttonSelect = GetComponent<Button>();
        GameObject saveZone = GameObject.FindWithTag("SaveZone");
        saveZone.GetComponent<SaveZoneTrigger>().button = buttonSelect;
        saveZone.GetComponent<SaveZoneTrigger>().InSaveZone();
        //print("asdfasdfadsfadfF");
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        buttonSelect.onClick.AddListener(() =>
        {
            SessionManager.instance_SessionManager.SaveInventory();
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
