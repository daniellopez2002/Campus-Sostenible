using UnityEngine;

public class ControladorInterfaz : MonoBehaviour
{
    [SerializeField]
    private GameObject interfazActivar;

    public void MostrarInterfaz()
    {
        interfazActivar.SetActive(true);
    }

    public void OcultarInterfaz()
    {
        interfazActivar.SetActive(false);
    }
}

