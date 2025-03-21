using UnityEngine;

public class StartEnginePlane : MonoBehaviour
{

    public bool TurnOn;

    public float EncenderTimer;
    public float ApagarTimer;

    public float acceleracionRotacion;

    public GameObject propellers;

    public PlayerControllerX playerControllerX;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        acceleracionRotacion = 0;   
        propellers = transform.GetChild(0).gameObject;
        playerControllerX = GetComponent<PlayerControllerX>();
    }

    // Update is called once per frame
    void Update()
    {
        if (TurnOn)
        {
            acceleracionRotacion += Time.deltaTime * 0.1f;
            propellers.GetComponent<Propeller>().rotatePropellerSpeed = acceleracionRotacion;
            this.gameObject.GetComponent<PlayerControllerX>().acceleration = acceleracionRotacion;

            playerControllerX.encendido = true;
            
            if (acceleracionRotacion > 1)
            {
                acceleracionRotacion = 1;       
            }
        }
        else
        {
            acceleracionRotacion -= Time.deltaTime * 0.1f;
            propellers.GetComponent<Propeller>().rotatePropellerSpeed = acceleracionRotacion;
            gameObject.GetComponent<PlayerControllerX>().acceleration = acceleracionRotacion;

            playerControllerX.encendido = false;

            if (acceleracionRotacion <= 0)
            {
                acceleracionRotacion = 0;
            }
        }
    }
}
