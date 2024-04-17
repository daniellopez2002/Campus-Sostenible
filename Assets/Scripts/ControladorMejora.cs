using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ControladorMejora : MonoBehaviour
{
    [SerializeField]Mejora Mejora;
    [SerializeField]TMP_Text Titulo;
    [SerializeField]TMP_Text Información;
    [SerializeField]GameObject Confirmación;
    [SerializeField] ControladorSala ControladorSala;

    private Vector3 _PosicionOriginal;
    private RectTransform _RectTransform;
    private Button _BotonCarta;
    // Start is called before the first frame update
    void Start()
    {
        _BotonCarta = GetComponent<Button>();
        _RectTransform = GetComponent<RectTransform>();
        _PosicionOriginal = GetComponent<RectTransform>().position;
        Mejora.NombreMinijuego = Mejora.DarNombre();
        Titulo.text = Mejora.NombreMinijuego;
        Información.text = Mejora.TextoInformacion;
        Confirmación.SetActive(false);
    }

    public void ClickCarta()
    {
        //Falta aplicar Blur
        _BotonCarta.enabled = false;
        _RectTransform.anchoredPosition = Vector2.zero;
        Confirmación.SetActive(true);
    }
    public void ConfirmarSeleccion()
    {

    }
    public void CancelarSeleccion()
    {
        _BotonCarta.enabled = true;

        _RectTransform.position = _PosicionOriginal;
        //_RectTransform.sizeDelta = _RectTransform.sizeDelta / 2f;
        Confirmación.SetActive(false);
    }
}
