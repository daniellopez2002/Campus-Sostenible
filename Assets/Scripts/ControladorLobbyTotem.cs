using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class ControladorLobbyTotem : MonoBehaviourPunCallbacks
{
    [SerializeField] GameObject ItemGrupo;
    [SerializeField] GameObject PanelGrupos;

    List<RoomInfo> _GruposRooms = new List<RoomInfo>();
    Dictionary<string, ItemGrupo> _GruposItems = new Dictionary<string, ItemGrupo>();


    private void Start()
    {

    }

    private void Update()
    {


       if (!PhotonNetwork.InRoom && !PhotonNetwork.InLobby)
        {
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    void AgregarGrupo(RoomInfo room)
    {
        string nombre = room.CustomProperties["Nombre"] as string;
        ItemGrupo _itemGrupo = new ItemGrupo();

        if (!_nombresRoom.Contains(nombre))
        {
            GameObject _item = Instantiate(ItemGrupo, PanelGrupos.transform);
            _itemGrupo = _item.GetComponent<ItemGrupo>();
            _GruposItems.Add(nombre, _itemGrupo);
        }
        else
        {

        }

        Dictionary<string, int> jugadores = room.CustomProperties["Players"] as Dictionary<string, int>;

        foreach (KeyValuePair<string, int> player in jugadores)
        {
            _itemGrupo.GetComponent<ItemGrupo>().AgregarJugador(player.Key);
        }
        

    }
    void ActualizarGrupo(RoomInfo room)
    {
        string nombre = room.CustomProperties["Nombre"] as string;
        Dictionary<string, int> jugadores = room.CustomProperties["Players"] as Dictionary<string, int>;
        ItemGrupo _item = _GruposItems[nombre];
        List<string> nombresJugadores = new List<string>();

        foreach (KeyValuePair<string, int> value in jugadores)
        {
            nombresJugadores.Add(value.Key);
        }

        _item.ActualizarJugadores(nombresJugadores);

    }

    void EliminarGrupo(string nombre)
    {
        ItemGrupo _item = _GruposItems[nombre];
        _GruposItems.Remove(nombre);
        _item.BorrarGrupo();
    }

    List <string> ListarGrupos()
    {
        List<string> grupos = new List<string>();

        foreach (KeyValuePair<string, ItemGrupo> value in _GruposItems)
        {
            grupos.Add(value.Key);
        }

        return grupos;
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Lobby Monitor Connected");
    }

    List<string> _nombresRoom = new List<string>();

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        _GruposRooms  = roomList;
        


        //agregar room
        foreach (RoomInfo room in roomList)
        {
            string nombre = room.CustomProperties["Nombre"] as string;
            if (!room.RemovedFromList)
            {
                _nombresRoom.Add(nombre);
                AgregarGrupo(room);
            }
            else
            {
                _nombresRoom.Remove(nombre);
                EliminarGrupo(nombre);
            }
            
            //if (_GruposItems.ContainsKey(nombre))
            //{
            //    //Actualizar ya esta creada
            //    ActualizarGrupo(room);
            //}
            //else
            //{
            //    //Crear
                
            //}
            
        }

        //foreach (string value in ListarGrupos())
        //{
        //    if (!_nombresRoom.Contains(value))
        //    {
        //        EliminarGrupo(value);
        //    }
        //}
    }

}

