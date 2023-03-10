using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour 
{
    Vector2 dir;
    public List<Transform> segments = new List<Transform>();   //Liste qui contient tout les segments du serpents
    [SerializeField] Transform segmentPrefab;
    void Start()
    {
        Time.timeScale = GameManager.instance.currentTimeScale;
        dir = Vector2.right;

        segments.Add(transform);    //Le premier segment est la tête du serpent

    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow) && dir.x != 0)   //Pour gérer les mouvements du serpent
        {
            dir = Vector2.up;
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow) && dir.x != 0)
        {
            dir = Vector2.down;
        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow) && dir.y != 0)
        {
            dir = Vector2.left;
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow) && dir.y != 0)
        {
            dir = Vector2.right;
        }
    }

    private void FixedUpdate()
    {

        for (int i = segments.Count - 1; i > 0; i--)
        {
            segments[i].position = segments[i - 1].position;
        }

        float x = Mathf.Round(transform.position.x) + dir.x;    //On arrondi la position du serpent pour sécuriser les valeurs exotiques
        float y = Mathf.Round(transform.position.y) + dir.y;

        transform.position = new Vector2(x, y);     //On applique la nouvelle position
    }

    void Grow() //On ajoute un segment
    {
        Transform segment = Instantiate(segmentPrefab);
        segment.position = segments[segments.Count - 1].position;
        segments.Add(segment);

        GameManager.instance.score++;
        GameManager.instance.loadScoreDisplay();
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.tag == "Food") Grow(); //Si le serpent touche de la nourriture il grandit
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        GameManager.instance.gameOver();
    }
}
