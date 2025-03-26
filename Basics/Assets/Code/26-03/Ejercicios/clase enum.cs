using UnityEngine;

namespace Enemy
{
    [System.Serializable]
    public class Controller1 : MonoBehaviour
    { 
        public int vida = 3;

        public int Suma()
        {
            return 1 + 1;
        }
    }

    [System.Serializable]
    public class Controller2
    {
        public int vida2 = 4;
    }
}