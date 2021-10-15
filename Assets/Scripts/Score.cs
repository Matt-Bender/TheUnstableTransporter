using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public GameObject player;
    //distance player has traveled
    private int distance;
    //variable to change screen text
    public static TextMeshProUGUI scoreText;
    void Start()
    {
        scoreText = gameObject.GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        if (player != null)
        {
            distance = (int)player.transform.position.x;
        }
        if (distance > 0)
        {
            scoreText.text = distance.ToString();
        }
    }
}
