[System.Serializable]
public class DatosEnemigos
{
    public string nombre;
    public int vida;
    public int dano;
}

[System.Serializable]

public class EnemigosSpawn
{
    public DatosEnemigos[] enemigos;
}