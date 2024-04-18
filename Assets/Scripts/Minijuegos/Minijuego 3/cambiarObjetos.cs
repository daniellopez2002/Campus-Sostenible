using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cambiarObjetos : MonoBehaviour
{
    public GameObject registroOn;
    public GameObject registroOff;

    public GameObject InicioOn;
    public GameObject IncioOff;

    // M?todo para mostrar un objeto y apagar otro
    public void MostrarYApagar1()
    {
        // Verificar que ambos objetos est?n asignados
        if (registroOn != null && registroOff != null)
        {
            // Mostrar el objeto que queremos mostrar
            registroOn.SetActive(true);

            // Apagar el objeto que queremos apagar
            registroOff.SetActive(false);
        }
        else
        {
            Debug.LogError("Asegurate de asignar los objetos en el inspector de Unity!");
        }
    }

    public void MostrarYApagar2()
    {
        // Verificar que ambos objetos est?n asignados
        if (InicioOn != null && IncioOff != null)
        {
            // Mostrar el objeto que queremos mostrar
            InicioOn.SetActive(true);

            // Apagar el objeto que queremos apagar
            IncioOff.SetActive(false);
        }
        else
        {
            Debug.LogError("Asegurate de asignar los objetos en el inspector de Unity!");
        }
    }
}