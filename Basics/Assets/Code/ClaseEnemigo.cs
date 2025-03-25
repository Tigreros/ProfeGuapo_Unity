[System.Serializable]
public class EnemigoJson
{
    public string nombre;
    public int vida;
}

[System.Serializable]
public class ListaEnemigos
{
    public EnemigoJson[] enemigos;
}