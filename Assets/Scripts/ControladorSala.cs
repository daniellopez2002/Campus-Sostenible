using System.Collections.Generic;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.Text;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class ControladorSala : MonoBehaviourPunCallbacks
{
    [SerializeField] TMP_Text TextoCodigo;
    [SerializeField] TMP_InputField TextoNombreGrupo;
    [SerializeField] GameObject LobbyGO;
    [SerializeField] GameObject InicioGO;
    [SerializeField] GameObject MejorasGO;
    [SerializeField] GameObject RankingGO;
    [SerializeField] Button BotonInicio;
    
    private PhotonView _PV;
    private List<string> _Jugadores = new List<string>();
    private int _PuntajeGlobal = 0;
    private Dictionary<string, float> _Mejoras = new Dictionary<string, float>();

    [HideInInspector]
    public string Sala = "";
    

    void Start()
    {
        _PV = GetComponent<PhotonView>();
        InicioGO.SetActive(true);
        LobbyGO.SetActive(false);
        //MejorasGO.SetActive(false);
        //RankingGO.SetActive(false);
        ConnectToPhoton();
        BotonInicio.interactable = false;
    }
    private void Update()
    {
        
    }
    void ConnectToPhoton()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Photon Server!");
        BotonInicio.interactable = true;
        
    }
 
    public void CrearPartida()
    {
        if (TextoNombreGrupo.text != "")
        {
            Sala = GenerarAlfanumerico();
            Dictionary<string, int> players = new Dictionary<string, int>() { { "", 0 } };

            // Parámetros para la creación de la sala
            RoomOptions _options = new RoomOptions
            {
                MaxPlayers = 6,
                EmptyRoomTtl = 60000,
                CustomRoomProperties = new Hashtable
            {
                { "Nombre", TextoNombreGrupo.text.ToUpper()},
                { "Puntaje", _PuntajeGlobal},
                { "Mejoras", _Mejoras},
                { "Players", new Dictionary<string, int>()}
            },
                CustomRoomPropertiesForLobby = new string[] { "Nombre", "Puntaje", "Mejoras", "Players" }


            };

            // Intentar crear la sala
            PhotonNetwork.CreateRoom(Sala, _options);
            TextoCodigo.text = Sala;
        }
        
    }

    private string GenerarAlfanumerico()
    {
        int _longitud = 4;
        const string caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        StringBuilder sb = new StringBuilder();
        System.Random rnd = new System.Random();

        for (int i = 0; i < _longitud; i++)
        {
            int index = rnd.Next(0, caracteres.Length);
            sb.Append(caracteres[index]);
        }

        return sb.ToString();
    }

    //Photon Log´s

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {


        if (newPlayer != PhotonNetwork.LocalPlayer)
        {
            PhotonNetwork.SetMasterClient(newPlayer);
            PhotonNetwork.LeaveRoom();
        }
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
