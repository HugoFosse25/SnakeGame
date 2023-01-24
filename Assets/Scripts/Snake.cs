using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour {
    Vector2 dir;
    void Start() {
    
        dir = Vector2.right;
    }

    void Update() {
    
        if(Input.GetKeyDown(KeyCode.UpArrow))   //Pour gérer les mouvements du serpent
        {
            dir = Vector2.up;
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            dir = Vector2.down;
        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            dir = Vector2.left;
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            dir = Vector2.right;
        }
    }

    private void FixedUpdate() {
        
        float x = Mathf.Round(transform.position.x) + dir.x;    //On arrondi la position du serpent pour sécuriser les valeurs exotiques
        float y = Mathf.Round(transform.position.y) + dir.y;

        transform.position = new Vector2(x, y);     //On applique la nouvelle position
    }
}