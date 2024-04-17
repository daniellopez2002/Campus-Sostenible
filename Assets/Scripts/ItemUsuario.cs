using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class ItemUsuario : MonoBehaviourPunCallbacks
{
    [SerializeField] TMP_Text Nombre;
    string _NickName;

    private void Update()
    {

    }
    public void SetUp(string _player)
    {
        _NickName = _player;
        Nombre.text = _player;
    }

    public void Borrar()
    {
        Destroy(gameObject);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.Log("Left = " + _NickName);
        if (otherPlayer.NickName == _NickName)
        {
            Destroy(gameObject);
        }
    }

    public override void OnLeftRoom()
    {
        Destroy(gameObject);
    }
}
