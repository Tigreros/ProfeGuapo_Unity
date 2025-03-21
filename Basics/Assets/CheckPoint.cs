using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("Hemos alcanzado un CheckPoint");

            PlayerPrefs.SetFloat("CheckPointX", transform.position.x);
            PlayerPrefs.SetFloat("CheckPointY", transform.position.y);
            PlayerPrefs.SetFloat("CheckPointZ", transform.position.z);

            PlayerPrefs.SetString("CheckPointString", "transform.position.z");

            PlayerPrefs.Save();
        }
    }
}
