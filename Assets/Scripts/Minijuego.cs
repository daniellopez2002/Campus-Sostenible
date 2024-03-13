using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NuevoMinijuego", menuName = "MiniJuego")]
public class Minijuego : ScriptableObject
{
    public int Id;
    public string NombreScene;
    //public List<Mejoras> Mejoras;
    public int Puntaje;
    public float Tiempo;
}
