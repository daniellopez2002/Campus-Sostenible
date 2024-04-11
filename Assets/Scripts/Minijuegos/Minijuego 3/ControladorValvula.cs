using UnityEngine;
using UnityEngine.UI;

public class ControladorValvula : MonoBehaviour
{
    public float velocidadGiro = 360.0f; // Velocidad de giro en grados por segundo
    public float duracionGiro = 2.0f; // Duraci�n del giro en segundos

    private bool girando = false; // Variable para verificar si el bot�n est� girando
    private float tiempoInicio; // Tiempo en el que comenz� el giro



    void Update()
    {
        // Verificar si se ha iniciado el giro
        if (girando)
        {
            // Calcular el �ngulo de giro basado en la velocidad y el tiempo transcurrido
            float anguloGiro = velocidadGiro * Time.deltaTime;

            // Aplicar el giro al bot�n
            transform.Rotate(0, 0, anguloGiro);

            // Verificar si ha pasado el tiempo de duraci�n del giro
            if (Time.time - tiempoInicio >= duracionGiro)
            {
                // Detener el giro
                girando = false;
            }
        }
    }

    public void IniciarGiro()
    {
        // Reiniciar el tiempo de inicio y establecer la variable de giro a verdadero
        tiempoInicio = Time.time;
        girando = true;
    }
}