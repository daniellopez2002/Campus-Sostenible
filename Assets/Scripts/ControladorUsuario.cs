using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;


public class ControladorUsuario : MonoBehaviourPunCallbacks
{
    [SerializeField] TMP_Text ErrorLog;
    [SerializeField] TMP_Text TextoSala;
    [SerializeField] TMP_InputField CodigoInput;
    [SerializeField] TMP_InputField NombreInput;
    [SerializeField] GameObject JoinGO;
    [SerializeField] GameObject SalaEsperaGO;
    [SerializeField] GameObject PanelUsuarios;
    [SerializeField] GameObject ItemUsuario;

    private List<string> _Jugadores = new List<string>();
    private Dictionary<string, GameObject> _ItemsJugadores = new Dictionary<string, GameObject>();

    private void Start()
    {
        SalaEsperaGO.SetActive(false);
        JoinGO.SetActive(true);
        ConnectToPhoton();
    }
    void ConnectToPhoton()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Photon Server!");
        PhotonNetwork.JoinLobby();
    }

    public void Conectar()
    {
        if (CodigoInput.text == "" || NombreInput.text == "")
        {
            ErrorLog.text = "Debes ingresar un codigo valido y un nombre de usuario valido";
        }
        else
        {
            JoinRoom();
        }
    }

    public void Desconectar()
    {
        LeftRoom();
    }

    void ActualizarLista()
    {
        foreach (Player player in PhotonNetwork.PlayerList)
        {
            if(player.NickName != "") AgregarJugador(player.NickName);
        }
    }
    void AgregarJugador(string jugador)
    {
        if (!_Jugadores.Contains(jugador))
        {
            _Jugadores.Add(jugador);
            GameObject _item = ItemUsuario;
            TMP_Text _textoUsuario = _item.GetComponentInChildren<TMP_Text>();
            if (_textoUsuario != null) _textoUsuario.text = jugador;
            Instantiate(_item, PanelUsuarios.transform);
            _ItemsJugadores.Add(jugador, _item);
        }
    }

    void BorrarJugador(string jugador)
    {
        GameObject item = _ItemsJugadores[jugador];
        _ItemsJugadores.Remove(jugador);
        _Jugadores.Remove(jugador);
        DestroyImmediate(item, true);

    }

    //Photon Log´s
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("Player = " + newPlayer.NickName);
        AgregarJugador(newPlayer.NickName);


    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        BorrarJugador(otherPlayer.NickName);
        base.OnPlayerLeftRoom(otherPlayer);
    }

    void JoinRoom()
    {
        // Intentar unirse a la sala por su nombre
        PhotonNetwork.JoinRoom(CodigoInput.text);
        // Asignar el nickname al jugador local
        PhotonNetwork.LocalPlayer.NickName = NombreInput.text;

    }

    void LeftRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Unido exitosamente a la sala: " + CodigoInput.text);
        // Aquí puedes implementar acciones adicionales una vez que te hayas unido a la sala
        TextoSala.text = PhotonNetwork.CurrentRoom.Name;
        ActualizarLista();
        SalaEsperaGO.SetActive(true);
        JoinGO.SetActive(false);
    }

    public override void OnLeftRoom()
    {
        SalaEsperaGO.SetActive(false);
        JoinGO.SetActive(true);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log("Error al unirse a la sala: " + message);
        ErrorLog.text = "Error al unirse a la sala: " + message;
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.LogWarningFormat("Disconnected from Photon Server for reason {0}", cause);
        ErrorLog.text = "Disconnected from Photon Server for reason "+ cause;
    }

}
