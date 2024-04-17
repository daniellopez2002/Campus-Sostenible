using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NuevaMejora", menuName = "Mejora")]
public class Mejora : ScriptableObject
{
    public enum OpcionesMinijuegos
    {
        Minijuego1,
        Minijuego2,
        Minijuego3,
        Minijuego4,
        Minijuego5
    }

    public OpcionesMinijuegos Minijuego;

    public string NombreMinijuego;

    [Range(0f, 25f)]
    public float PorcentajeDeMejoras;

    public string TextoInformacion;

    public string DarNombre()
    {
        string _nombre = "";
        switch (Minijuego)
        {
            case OpcionesMinijuegos.Minijuego1: _nombre = "Sedimentación Eficiente"; break;
            case OpcionesMinijuegos.Minijuego2: _nombre = "Filtración Efectiva"; break;
            case OpcionesMinijuegos.Minijuego3: _nombre = "Separación por Flotación"; break;
            case OpcionesMinijuegos.Minijuego4: _nombre = "Desinfección UV"; break;
            case OpcionesMinijuegos.Minijuego5: _nombre = "Recolección de Agua"; break;
        }

        return _nombre;
    }
}
