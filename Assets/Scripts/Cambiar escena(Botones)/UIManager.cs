using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject[] interfaces; // Arreglo de todas tus interfaces

    public void ActivateInterface(int index)
    {
        foreach (GameObject intf in interfaces)
        {
            intf.SetActive(false); // Desactiva todas las interfaces
        }
        interfaces[index].SetActive(true); // Activa solo la interfaz deseada
    }
}