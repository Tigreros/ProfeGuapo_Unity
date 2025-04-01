using System.Collections;
using UnityEngine;

public class MoveNet : MonoBehaviour
{
    public Transform from;
    public Transform to;

    public float timeCount = 0.0f;
    public bool control;

    private void Start()
    {
        to = GameObject.Find("To").transform;
        from = this.transform;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(AnimationNet());
        }

        if (control)
        {
            timeCount = timeCount + Time.deltaTime;
            transform.rotation = Quaternion.Slerp(transform.rotation, to.rotation, timeCount);
        }
    }
    void TryCatchBug()
    {

    }
    IEnumerator AnimationNet()
    {
        control = true;
        yield  return new WaitForSeconds(1);
        timeCount = 0;
        to = from;
        yield return new WaitForSeconds(0.5f);
        control = false;
    }
}
