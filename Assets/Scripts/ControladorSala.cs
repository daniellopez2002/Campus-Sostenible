using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.Text;
using TMPro;

public class ControladorSala : MonoBehaviourPunCallbacks
{
    [SerializeField] TMP_Text TextoCodigo;
    [SerializeField] GameObject LobbyGO;
    [SerializeField] GameObject InicioGO;
    [SerializeField] GameObject PanelUsuarios;
    [SerializeField] GameObject ItemUsuario;

    private List<string> _Jugadores = new List<string>();
    private Dictionary<string, GameObject> _ItemsJugadores = new Dictionary<string, GameObject>();

    void Start()
    {
        InicioGO.SetActive(true);
        LobbyGO.SetActive(false);
        ConnectToPhoton();
    }

    void ConnectToPhoton()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Photon Server!");
    }

    
    public void CrearPartida()
    {
        string codigo = GenerarAlfanumerico();

        // Parámetros para la creación de la sala
        RoomOptions options = new RoomOptions();
        options.MaxPlayers = 6; // Número máximo de jugadores en la sala

        // Nombre de la sala (se generará uno automáticamente si se deja como null)
        string roomName = codigo;

        // Intentar crear la sala
        PhotonNetwork.CreateRoom(roomName, options, TypedLobby.Default);
        TextoCodigo.text = codigo;
    }
    private string GenerarAlfanumerico()
    {
        int longitud = 4;
        const string caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        StringBuilder sb = new StringBuilder();
        System.Random rnd = new System.Random();

        for (int i = 0; i < longitud; i++)
        {
            int index = rnd.Next(0, caracteres.Length);
            sb.Append(caracteres[index]);
        }

        return sb.ToString();
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
        Debug.Log("Player = "+ newPlayer.NickName);
        AgregarJugador(newPlayer.NickName);
        
        
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        BorrarJugador(otherPlayer.NickName);
        base.OnPlayerLeftRoom(otherPlayer);
    }
    public override void OnCreatedRoom()
    {
        InicioGO.SetActive(false);
        LobbyGO.SetActive(true);
        Debug.Log("Sala creada exitosamente");

    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.LogWarningFormat("Disconnected from Photon Server for reason {0}", cause);
    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Error al crear la sala: " + message);
    }
}
