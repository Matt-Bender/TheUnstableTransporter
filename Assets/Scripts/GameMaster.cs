using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{

    private static GameMaster instance;
    public Vector2 lastCheckPointPos;
    //just to ensure endgame doesn't get called multiple times
    bool gameHasEnded = false;
    public GameObject player;
    static public int finalPlayerScore = 50;
    public int setFinalScore;
    public GameObject scoreBoard;

    void Start()
    {
    }
    public int getFinalScore()
    {
        setFinalScore = (int)player.transform.position.x;
        Destroy(player);
        return setFinalScore;
    }
    public void EndGame()
    {
        if (SceneManager.GetActiveScene().name == "Infinite Runner")
        {
            if (!gameHasEnded)
            {
                gameHasEnded = true;
                Debug.Log("GAME OVER");
                Invoke("Restart", 0.1f);
            }
        }
        else
        {
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
        }
    }
    void Restart()
    {

        scoreBoard.gameObject.SetActive(true);
        gameHasEnded = false;
    }
}
