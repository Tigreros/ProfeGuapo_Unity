using System.Threading;
using UnityEngine;

public class UtilitiesFloating : MonoBehaviour
{
    Vector3 startPosition;
    public float lambda;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        transform.position = Vector3.Lerp(startPosition, new Vector3(startPosition.x, startPosition.y + (lambda / 2), startPosition.z), Mathf.Abs(Mathf.Sin(Time.time * (lambda/2))));
        transform.Rotate(0.0f, 0.0f, lambda/10, Space.Self);
    }
}
