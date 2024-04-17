using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Linq;

public class ItemGrupo : MonoBehaviour
{
    [SerializeField] TMP_Text TextoNombreGrupo;
    [SerializeField] GameObject ItemUsuario;
    [SerializeField] public GameObject PanelUsuarios;

    [HideInInspector]
    public string NombreGrupo;
    [HideInInspector]
    public  Dictionary<string, ItemUsuario> _Usuarios = new Dictionary<string, ItemUsuario>();

    public void SetUp(string nombreGrupo)
    {
        NombreGrupo = nombreGrupo;
        TextoNombreGrupo.text = NombreGrupo;
    }

    public void BorrarGrupo()
    {
        Destroy(gameObject);
    }

    public void AgregarJugador(string nombreJugador)
    {
        GameObject _item = Instantiate(ItemUsuario, PanelUsuarios.transform);
        _item.GetComponent<ItemUsuario>().SetUp(nombreJugador);
        _Usuarios.Add(nombreJugador, _item.GetComponent<ItemUsuario>());
    }

    void EliminarJugador(string nombreJugador)
    {
        ItemUsuario _item = _Usuarios[nombreJugador];
        _Usuarios.Remove(nombreJugador);
        _item.Borrar();

    }

    public void ActualizarJugadores(List<string> jugadores)
    {
        //tengo que mirar si existwe / si no en existe CREARLO / si existe pero no llega BORRARLO
        List<string> nombres = ListarNombres();

        IEnumerable<string> diferencia = jugadores.Except(nombres);
        if (diferencia.Any())
        {
            foreach (string nombre in diferencia)
            {
                AgregarJugador(nombre);
            }
        }

        IEnumerable<string> diferencia_2 = nombres.Except(jugadores);
        if (diferencia_2.Any())
        {
            foreach (string nombre in diferencia_2)
            {
                EliminarJugador(nombre);
            }
        }
        

    }

    List<string> ListarNombres()
    {
        List<string> nombres = new List<string>();

        foreach (KeyValuePair <string, ItemUsuario> value in _Usuarios)
        {
            nombres.Add(value.Key);
        }

        return (nombres);
    }
}
