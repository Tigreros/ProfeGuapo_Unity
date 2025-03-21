using UnityEngine;

public class Death : MonoBehaviour
{
    public float posX;
    public float posY;
    public float posZ;

    public string stringGuardado;

    [ContextMenu("Checkpoint")]
    public void DeathCheckpoint()
    {
        posX = PlayerPrefs.GetFloat("CheckPointX", 50);
        posY = PlayerPrefs.GetFloat("CheckPointY", 50);
        posZ = PlayerPrefs.GetFloat("CheckPointZ", 50);


        stringGuardado = PlayerPrefs.GetString("CheckPointString", "No existe pero bueno, ya tu sabe");


        transform.position = new Vector3(posX, posY, posZ); 
    }
}
