using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_collider : MonoBehaviour
{
    public Gameloop gameloop;
    private Rigidbody2D bird_rigibody2d;
    void Start()
    {
        bird_rigibody2d = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            gameloop.EndGame();
        }
    }
}