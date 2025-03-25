[System.Serializable]
public class PersonajeAnidado2
{
    public string nombre;
    public Stats stats;
}

[System.Serializable]
public class Stats
{
    public Vida vida;
    public int mana;
}

[System.Serializable]
public class Vida
{
    public int porcentaje;
    public string Estado;
}