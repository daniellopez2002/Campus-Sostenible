using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine;
using UnityEngine.UI;

public class SpawnerMinijuego1 : MonoBehaviour
{
    [Header("Target")]
    public GameObject prefab;

    [Header("Gameplay")]
    public float interval;
    public float minimumX;
    public float maximumX;
    public float y;

    [Header("Visuals")]
    public Sprite[] sprites;

    private RectTransform canvasRect;

    void Start()
    {
        canvasRect = GetComponentInParent<Canvas>().GetComponent<RectTransform>();
        InvokeRepeating("Spawn", interval, interval);
    }

    private void Spawn()
    {
        // Instanciar el objeto y establecer su posición
        GameObject instance = Instantiate(prefab, transform);
        RectTransform rectTransform = instance.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector2(
            Random.Range(minimumX, maximumX),
            y
        );

        // Seleccionar un sprite aleatorio y asignarlo al objeto instanciado
        Sprite randomSprite = sprites[Random.Range(0, sprites.Length)];
        instance.GetComponent<Image>().sprite = randomSprite;
    }
}

