using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WackOnCollision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        //checks if obstacle his is an obstacle
        if (col.gameObject.tag == "Obstacle")
        {
            SceneManager.LoadScene("Main Menu");
        }
    }
}
