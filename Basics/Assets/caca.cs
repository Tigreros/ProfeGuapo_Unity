using UnityEngine;
using UnityEngine.EventSystems;

public class caca : MonoBehaviour
{

    public controller c_controller;


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Convierte la posición del mouse en coordenadas del mundo
            Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Lanza el raycast desde la posición del mouse
            RaycastHit2D hit = Physics2D.Raycast(mouseWorldPos, Vector2.zero);

            // Si el raycast colisiona con algo
            if (hit.collider != null)
            {
                Debug.Log("Objeto seleccionado: " + hit.collider.name);
                // Aquí puedes hacer lo que necesites con el objeto seleccionado
                // Por ejemplo, cambiar color o activar una función
                hit.collider.GetComponent<SpriteRenderer>().color = Color.red;
                c_controller.selectedPlaca = hit.collider.gameObject;
                c_controller.posX = hit.collider.transform.position.x;
                c_controller.posY = hit.collider.transform.position.y;
            }
        }
    }



    void OnCollisionEnter2D(Collision2D collision)
    {
        c_controller.col = true;
    }


}
