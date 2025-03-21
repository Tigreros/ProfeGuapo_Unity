using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{

    public int count;
    float timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        count = 90;
        timer = 1;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            print(Counter());
            timer = 1;
        }
    }

    public int Counter()
    {
        count = count - 1;
        return count;
    }

}
