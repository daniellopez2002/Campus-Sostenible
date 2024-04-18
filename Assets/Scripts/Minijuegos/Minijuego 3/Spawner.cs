using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objetoPrefab; // Prefab del objeto que quieres spawnear
    public int cantidadObjetos = 10; // Cantidad de objetos a spawnear

    private RectTransform canvasRectTransform; // RectTransform del Canvas

    void Start()
    {
        // Obtener el RectTransform del Canvas
        canvasRectTransform = GetComponent<RectTransform>();

        // Spawnear los objetos
        SpawnObjetos();
    }

    void SpawnObjetos()
    {
        for (int i = 0; i < cantidadObjetos; i++)
        {
            // Instanciar el objeto
            GameObject nuevoObjeto = Instantiate(objetoPrefab, transform);

            // Obtener el RectTransform del nuevo objeto
            RectTransform objetoRectTransform = nuevoObjeto.GetComponent<RectTransform>();

            // Posicionar el objeto en una posición aleatoria dentro del Canvas
            Vector2 posicionAleatoria = GetRandomPositionInsideCanvas(objetoRectTransform.sizeDelta);
            objetoRectTransform.anchoredPosition = posicionAleatoria;
        }
    }

    Vector2 GetRandomPositionInsideCanvas(Vector2 objetoSize)
    {
        // Obtener el tamaño del Canvas
        float canvasWidth = canvasRectTransform.rect.width;
        float canvasHeight = canvasRectTransform.rect.height;

        // Calcular las posiciones mínimas y máximas dentro del Canvas
        float minX = -canvasWidth / 2 + objetoSize.x / 2;
        float maxX = canvasWidth / 2 - objetoSize.x / 2;
        float minY = -canvasHeight / 2 + objetoSize.y / 2;
        float maxY = canvasHeight / 2 - objetoSize.y / 2;

        // Generar una posición aleatoria dentro del rango calculado
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        return new Vector2(randomX, randomY);
    }
}