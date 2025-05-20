using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class controller : MonoBehaviour
{

    public GameObject selectedPlaca;
    public float posX;
    public float posY;
    public bool col;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetAxis("Horizontal") > 0)
        {
            posX+=0.1F;
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            posX -= 0.1F;
        }

        if (Input.GetAxis("Vertical") > 0)
        {
            posY+=0.1F;
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            posY -= 0.1F;
        }

        if (selectedPlaca != null && col == false)
        {
            selectedPlaca.transform.position = new Vector3(posX, posY, 0);
        }
    }



}
