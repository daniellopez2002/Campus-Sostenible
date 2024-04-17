using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    [Header("Velocidades")]
    public float minimumXSpeed;
    public float maximumXSpeed;
    public float minimumYSpeed;
    public float maximumYSpeed;
    public float rotationSpeed = 50f;
    

    [Header("Gameplay")]
    public float lifetime;

    // Update is called once per frame
    void Start()
    {
        // Arrojar el obj
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (
            Random.Range(minimumXSpeed,maximumXSpeed),
            Random.Range(minimumYSpeed,maximumYSpeed)
        );

        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        
    }

}
