using UnityEngine;

public class buclesExe1 : MonoBehaviour
{

    public int numDado = 5;

    [SerializeField]
    private int vida = 5;


    protected int numDado2 = 5;
    bool escudoActive;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool isEscudoActive()
    {
        return true;
    }

    public int DamageToPlayer(int damage)
    {
        return vida - damage;
    }

}
