using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class destruirObj : MonoBehaviour
{
    void Update()
    {
        // Verificar si se hizo clic con el botón izquierdo del ratón
        if (Input.GetMouseButtonDown(0))
        {
            // Lanzar un rayo desde la posición del ratón hacia adelante en la escena
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            // Verificar si el rayo golpea este objeto
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                // Desactivar este objeto
                gameObject.SetActive(false);
            }
        }
    }
}

    


