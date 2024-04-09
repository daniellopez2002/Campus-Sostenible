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
            case OpcionesMinijuegos.Minijuego1: _nombre = "Sedimentaci�n Eficiente"; break;
            case OpcionesMinijuegos.Minijuego2: _nombre = "Filtraci�n Efectiva"; break;
            case OpcionesMinijuegos.Minijuego3: _nombre = "Separaci�n por Flotaci�n"; break;
            case OpcionesMinijuegos.Minijuego4: _nombre = "Desinfecci�n UV"; break;
            case OpcionesMinijuegos.Minijuego5: _nombre = "Recolecci�n de Agua"; break;
        }

        return _nombre;
    }
}
