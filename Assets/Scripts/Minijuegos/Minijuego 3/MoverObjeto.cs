using UnityEngine;

public class MoverObjeto : MonoBehaviour
{
    public float velocidad = 5.0f; // Velocidad constante del movimiento en la coordenada Y

    void Update()
    {
        // Obtener la posición actual del objeto
        Vector3 posicionActual = transform.position;

        // Calcular la nueva posición del objeto con respecto al tiempo y velocidad
        float movimientoY = velocidad * Time.deltaTime;
        Vector3 nuevaPosicion = new Vector3(posicionActual.x, posicionActual.y + movimientoY, posicionActual.z);

        // Actualizar la posición del objeto
        transform.position = nuevaPosicion;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Verificar si el objeto con el que colisionó tiene el tag "Limite"
        if (collision.gameObject.CompareTag("Limite"))
        {
            // Detener el movimiento del objeto estableciendo la velocidad a 0
            velocidad = 0.0f;
        }
    }
}