using UnityEngine;
using UnityEngine.InputSystem.XR;

public class PlataformaSalto : MonoBehaviour
{

    public bool isJump;
    public bool isSlow;
    public bool isCinta;

    public float cintaSpeed;
    int cintaDirection;
    public bool isDirectionRight;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isDirectionRight)
        {
            cintaDirection = 1;
        }
        else
        {
            cintaDirection = -1;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isJump)
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<eJERCICIOcOLISIONES>().boostSalto = 2.5f;
            }
        }

        if (isSlow)
        {
            if (other.CompareTag("Player"))
            {
                print("WEA");
                other.GetComponent<eJERCICIOcOLISIONES>().playerSpeed = 0.1f;
            }
        }


    }


    private void OnCollisionEnter(Collision other)
    {
        if (isJump)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                other.gameObject.GetComponent<eJERCICIOcOLISIONES>().boostSalto = 2.5f;
            }
        }

        if (isSlow)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                print("WEA");
                other.gameObject.GetComponent<eJERCICIOcOLISIONES>().playerSpeed = 0.1f;
            }
        }


    }

    private void OnTriggerStay(Collider other)
    {
        if (isCinta)
        {
            if (other.CompareTag("Player"))
            {
                //other.GetComponent<eJERCICIOcOLISIONES>().controller.Move(new Vector3(cintaDirection * Time.deltaTime * cintaSpeed, 0, 0));
                other.gameObject.transform.Translate(new Vector3(cintaDirection * Time.deltaTime * cintaSpeed, 0, 0));
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (isJump)
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<eJERCICIOcOLISIONES>().boostSalto = 1f;
            }
        }

        if (isSlow)
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<eJERCICIOcOLISIONES>().playerSpeed = 1f;
            }
        }
    }
}
