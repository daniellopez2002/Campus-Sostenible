using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObj : MonoBehaviour
{
    [SerializeField] GameObject[] ObjPrefab;
    [SerializeField] float secondSpawn = 0.5f;
    [SerializeField] float Litmin;
    [SerializeField] float Litmax;
    void Start()
    {
        StartCoroutine(ObjSpawn());
    }

    IEnumerator ObjSpawn()
    {
        while(true)
        {
            var wanted = Random.Range(Litmax,Litmin);
            var position = new Vector3(wanted,transform.position.y);
            GameObject gameObject = Instantiate(ObjPrefab[Random.Range(0,ObjPrefab.Length)],
            position, Quaternion.identity);
            yield return new WaitForSeconds(secondSpawn);
            Destroy(gameObject, 5f);
        }
    }

    
}
