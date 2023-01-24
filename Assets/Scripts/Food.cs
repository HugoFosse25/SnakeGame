using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] Collider2D zoneSpawn;
    void Start()
    {
        SpawnFood();
    }

    void SpawnFood() 
    {
        Bounds bounds = zoneSpawn.bounds;

        float x = Mathf.Round(Random.Range(bounds.min.x, bounds.max.x));    //On défini les limites de spawn de la nourriture
        float y = Mathf.Round(Random.Range(bounds.min.y, bounds.max.y));

        transform.position = new Vector2(x, y);
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        SpawnFood();
    }
}
