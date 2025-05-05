using UnityEngine;
using UnityEngine.UI;

public class PauseMenuLoadData : MonoBehaviour
{

    public Button buttonSelect;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        buttonSelect = GetComponent<Button>();

        buttonSelect.onClick.AddListener(() =>
        {
            SessionManager.instance_SessionManager.LoadSession();
            //go_Toggle.GetComponent<togglePrefabSlots>().FlipFlop();
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
