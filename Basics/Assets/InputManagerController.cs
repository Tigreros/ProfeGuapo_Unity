using UnityEngine;

public class InputManagerController : MonoBehaviour
{

    public GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Megaman");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M)) { player.GetComponent<MegamanAttack>().LanzarAttak();  }
    }
}
