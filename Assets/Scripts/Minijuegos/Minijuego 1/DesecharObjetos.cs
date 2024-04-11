using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesecharObjetos : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Basura")
        {
            Destroy(gameObject);
        }
    }
}

