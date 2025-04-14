using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class ManagerLog : MonoBehaviour
{

    public static ManagerLog instance_Log 
    {  get; private set; }

    [Header("Referencias")]
    //public TextMeshProUGUI logText;
    public ScrollRect scrollRect;
    public GameObject parent;


    private void Awake()
    {
        if(instance_Log != null && instance_Log != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance_Log = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void Start()
    {
        scrollRect = GetComponent<ScrollRect>();   
        parent = transform.GetChild(0).GetChild(0).transform.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            Log("CACA" , "Normal");
        }
    }


    public void Log(string message, string type)
    {
        string timeStamp = System.DateTime.Now.ToString("HH:mm:ss");
        string formatted = $"[{timeStamp}] : {message}";

        GameObject instance = Instantiate(Resources.Load("LogMessage", typeof(GameObject)), parent.transform) as GameObject;
        instance.GetComponent<TextMeshProUGUI>().text = formatted;
        instance.GetComponent<TextMeshProUGUI>().overrideColorTags = true;

        scrollRect.verticalNormalizedPosition = 0f;

        switch (type)
        {
            case "pickUp":
                instance.GetComponent<TextMeshProUGUI>().color = new Color(1,0,0);
                //Debug.Log("pickUp");
                break;

            case "Normal":
                instance.GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1);
                //Debug.Log("Normal");
                break;

            case "fused":
                instance.GetComponent<TextMeshProUGUI>().color = new Color(0.77f, 0, 1);
                //Debug.Log("Normal");
                break;

            default:
                instance.GetComponent<TextMeshProUGUI>().color = new Color(0, 0, 0);
                break;
        }

    }


}
