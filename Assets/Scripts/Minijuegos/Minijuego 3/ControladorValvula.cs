using UnityEngine;
using UnityEngine.UI;

public class ControladorValvula : MonoBehaviour
{
    public Button boton; // Referencia al botón que girará y controlará el movimiento de los objetos
    public Rigidbody2D[] objetosMoverY; // Referencia a los objetos que se moverán en la coordenada Y
    public float velocidadGiro = 360.0f; // Velocidad de giro en grados por segundo
    public float velocidadMoverY = 5.0f; // Velocidad constante de movimiento en la coordenada Y

    private bool girando = false; // Variable para verificar si el botón está girando
    private bool moviendo = false; // Variable para verificar si los objetos se están moviendo
    private float tiempoInicio; // Tiempo en el que comenzó el giro

    void Start()
    {
        // Añadir un listener al botón para detectar clics o toques
        boton.onClick.AddListener(ControlarMovimientoObjetos);
    }

    void Update()
    {
        // Verificar si se ha iniciado el giro
        if (girando)
        {
            // Calcular el ángulo de giro basado en la velocidad y el tiempo transcurrido
            float anguloGiro = velocidadGiro * Time.deltaTime;

            // Aplicar el giro al botón
            transform.Rotate(0, 0, anguloGiro);

            // Verificar si ha pasado el tiempo de duración del giro
            if (Time.time - tiempoInicio >= 1.0f)
            {
                // Detener el giro
                girando = false;
            }
        }

        // Mover los objetos en la coordenada Y con velocidad constante si la variable moviendo es verdadera
        if (moviendo)
        {
            foreach (Rigidbody2D objeto in objetosMoverY)
            {
                float movimientoY = velocidadMoverY * Time.deltaTime;
                objeto.MovePosition(new Vector2(objeto.position.x, objeto.position.y + movimientoY));
            }
        }
    }

    public void IniciarGiro()
    {
        // Reiniciar el tiempo de inicio y establecer la variable de giro a verdadero
        tiempoInicio = Time.time;
        girando = true;
    }

    void ControlarMovimientoObjetos()
    {
        // Invertir el estado del movimiento de los objetos (moviendo o no)
        moviendo = !moviendo;

        // Reiniciar el tiempo de inicio si se inicia el movimiento de los objetos
        if (moviendo)
        {
            tiempoInicio = Time.time;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Verificar si se colisionó con un collider que tiene el tag "Limite"
        if (collision.gameObject.CompareTag("Limite"))
        {
            // Detener el movimiento de los objetos
            moviendo = false;
        }
    }
}