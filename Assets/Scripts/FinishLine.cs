using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //checks if obstacle his is an obstacle
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Main Menu");

        }
    }
}
    

