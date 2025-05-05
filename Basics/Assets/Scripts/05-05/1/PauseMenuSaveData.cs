using UnityEngine;
using UnityEngine.UI;

public class PauseMenuSaveData : MonoBehaviour
{

    public Button buttonSelect;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        buttonSelect = GetComponent<Button>();

        buttonSelect.onClick.AddListener(() =>
        {
            SessionManager.instance_SessionManager.SaveSession();
            //go_Toggle.GetComponent<togglePrefabSlots>().FlipFlop();
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
