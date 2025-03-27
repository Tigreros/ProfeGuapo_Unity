[System.Serializable]
public class Mochila
{
    public Pokeball[] pokeballs;
    public Baya[] bayas;
    public Util[] utiles;
}

[System.Serializable]
public class Pokeball
{
    public string nombre;
    public int cantidad;
}

[System.Serializable]
public class Baya
{
    public string nombre;
    public string efecto;
    public int cantidad;
}

[System.Serializable]
public class Util
{
    public string nombre;
    public string tipo;
    public int cantidad;
}