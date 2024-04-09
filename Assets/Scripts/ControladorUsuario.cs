using System.Collections.Generic;
using ExitGames.Client.Photon;
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

    private Usuario _Usuario;
    private PhotonView _PV;
    private List<string> _Jugadores = new List<string>();
    private Dictionary<string, GameObject> _ItemsJugadores = new Dictionary<string, GameObject>();

    private void Start()
    {
        _Usuario = GetComponent<Usuario>();
        _PV = GetComponent<PhotonView>();
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
        Dictionary<string, int> Players = PhotonNetwork.CurrentRoom.CustomProperties["Players"] as Dictionary<string, int>;
        Players.Remove(_Usuario.NickName);
        PhotonNetwork.CurrentRoom.SetCustomProperties(new Hashtable { { "Players", Players } });
        LeftRoom();
    }

    void ActualizarLista()
    {
        foreach (Player player in PhotonNetwork.PlayerList)
        {
            if(player.NickName != "") AgregarJugador(player);
        }
    }
    void AgregarJugador(Player jugador)
    {
        if (!_Jugadores.Contains(jugador.NickName))
        {
            _Jugadores.Add(jugador.NickName);
            GameObject _item = Instantiate(ItemUsuario, PanelUsuarios.transform);
            _item.GetComponent<ItemUsuario>().SetUp(jugador.NickName);
            _ItemsJugadores.Add(jugador.NickName, _item);
        }
    }

    void BorrarJugador(string jugador)
    {
        GameObject item = _ItemsJugadores[jugador];
        _ItemsJugadores.Remove(jugador);
        _Jugadores.Remove(jugador);
        //DestroyImmediate(item, true);

    }

    //Photon Log´s
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        AgregarJugador(newPlayer);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        if (otherPlayer.NickName != "")
        {
            BorrarJugador(otherPlayer.NickName);
        }
        
        base.OnPlayerLeftRoom(otherPlayer);
    }

    void JoinRoom()
    {
        _Usuario.NickName = NombreInput.text;
        Hashtable customPropierties = new Hashtable();
        customPropierties.Add("Puntaje", _Usuario.Puntaje);

        PhotonNetwork.JoinRoom(CodigoInput.text.ToUpper());

        PhotonNetwork.LocalPlayer.NickName = _Usuario.NickName;
        PhotonNetwork.LocalPlayer.SetCustomProperties(customPropierties);
    }

    void LeftRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Unido exitosamente a la sala: " + CodigoInput.text);
        object list = PhotonNetwork.CurrentRoom.CustomProperties["Players"];
        Debug.Log(list);
        PhotonNetwork.CurrentRoom.SetCustomProperties(new Hashtable { { "Players", new Dictionary<string, int>() { { _Usuario.NickName, _Usuario.Puntaje } } } });
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
