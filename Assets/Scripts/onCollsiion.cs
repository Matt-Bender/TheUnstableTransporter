using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onCollsiion : MonoBehaviour
{
    //public Movement move;
    public Rigidbody2D player;

    void OnCollisionEnter2D(Collision2D col)
    {
        //checks if obstacle his is an obstacle
        if (col.gameObject.tag == "Obstacle")
        {
            FindObjectOfType<GameMaster>().EndGame();
        }
    }
}
