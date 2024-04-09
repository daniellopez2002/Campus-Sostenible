using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ControladorUsuario))]
public class Usuario : MonoBehaviour
{
    public string Nombre;
    public string NickName;
    public string Correo;
    public int Puntaje;

    Usuario _Usuario;

    private void Awake()
    {
        if (_Usuario == null)
        {
            _Usuario = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ReiniciarPuntaje()
    {

    }
}
