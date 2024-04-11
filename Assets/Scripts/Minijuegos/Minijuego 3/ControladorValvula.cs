using UnityEngine;
using UnityEngine.UI;

public class ControladorValvula : MonoBehaviour
{
    public float velocidadGiro = 360.0f; // Velocidad de giro en grados por segundo
    public float duracionGiro = 2.0f; // Duración del giro en segundos

    private bool girando = false; // Variable para verificar si el botón está girando
    private float tiempoInicio; // Tiempo en el que comenzó el giro



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