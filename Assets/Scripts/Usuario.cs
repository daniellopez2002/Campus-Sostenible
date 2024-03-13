using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NuevoUsuario", menuName = "Usuario")]
public class Usuario : ScriptableObject
{
    string Nombre;
    string NickName;
    string Correo;
    int Puntaje;
}
