using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu_Desplegable : MonoBehaviour
{
    public GameObject objetoAEncenderApagar;

    // Método para encender y apagar el objeto
    public void EncenderApagarObjeto()
    {
        // Verificar si el objeto está activo o no
        if (objetoAEncenderApagar.activeSelf)
        {
            // Si está activo, desactivarlo
            objetoAEncenderApagar.SetActive(false);
        }
        else
        {
            // Si está desactivado, activarlo
            objetoAEncenderApagar.SetActive(true);
        }
    }
}


