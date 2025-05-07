using UnityEngine;
using UnityEngine.UI;

public class FastSave : MonoBehaviour
{

    public Button buttonSelect;
    public GameObject fastSaveZone;

    public void Awake()
    {
        fastSaveZone = GameObject.FindWithTag("FastSaveZone");
        buttonSelect = GetComponent<Button>();
        print(fastSaveZone.GetComponent<FastSaveZoneTrigger>().inZone);


        if (fastSaveZone.GetComponent<FastSaveZoneTrigger>().inZone)
        {
            fastSaveZone.GetComponent<FastSaveZoneTrigger>().button = buttonSelect;
            fastSaveZone.GetComponent<FastSaveZoneTrigger>().InSaveZone();
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }


    //Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        buttonSelect.onClick.AddListener(() =>
        {
            SessionManager.instance_SessionManager.FastSave();
        });
    }
}
