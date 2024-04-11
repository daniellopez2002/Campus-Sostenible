using UnityEngine;

public class MoverObjetoY : MonoBehaviour
{
    private bool moviendo = true; // Variable para verificar si el objeto se está moviendo

    void Update()
    {
        // Mover el objeto en la coordenada Y si la variable moviendo es verdadera
        if (moviendo)
        {
            Vector3 posicionActual = transform.position;
            Vector3 nuevaPosicion = new Vector3(posicionActual.x, posicionActual.y + Time.deltaTime, posicionActual.z);
            transform.position = nuevaPosicion;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Verificar si el objeto colisionó con un collider que tiene el tag "Limite"
        if (collision.gameObject.CompareTag("Limite"))
        {
            // Detener el movimiento del objeto en la coordenada Y
            moviendo = false;
        }
    }
}