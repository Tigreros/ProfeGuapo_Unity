using System;
using UnityEngine;
using UnityEngine.UI;

public class InputUserName : MonoBehaviour
{
    public InputField buttonSelect;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        buttonSelect = GetComponent<InputField>();

        buttonSelect.onSubmit.AddListener(delegate { LockInput(buttonSelect); });
    }

    private void ValueChangeCheck()
    {
        Debug.Log(buttonSelect.text);
    }

    private void LockInput(InputField input)
    {
        if (input.text.Length > 0)
        {
            Debug.Log($"Text has been entered {input.text}");
            SessionManager.instance_SessionManager.ChangeUserName(input.text);
        }
        else if (input.text.Length == 0)
        {
            Debug.Log("Main Input Empty");
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
