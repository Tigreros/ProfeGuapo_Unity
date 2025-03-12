using UnityEngine;

public class movimiento : MonoBehaviour
{
    public Transform from;
    public Transform to;

    public float smoothRotation;

    private float timeCount = 0.0f;

    void Update()
    {
        transform.rotation = Quaternion.Slerp(from.rotation, to.rotation, timeCount);
        timeCount = (timeCount + Time.deltaTime * smoothRotation);
    }

    // Update is called once per frame
    //void Update()
    //{
    //    // teleportar al objeto a la nueva posicion
    //    //transform.position = new Vector3(1,2,transform.position.z + move);
    //    //transform.position += Vector3.forward * move;

    //    transform.Rotate(Vector3.up, 0.1f);
    //    //transform.rotation = new Quaternion(90,45,45,30);

    //    // Esto mueve el objeto de forma fisica
    //    //transform.Translate(new Vector3(0, 0, transform.position.z + move) * Time.deltaTime);
    //}
}
