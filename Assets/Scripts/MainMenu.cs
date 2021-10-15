using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Directs to varous scenes
    public void PlayGame()
    {
        SceneManager.LoadScene("Infinite Runner");
    }
    public void PlayTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void PlayWacky()
    {
        SceneManager.LoadScene("Wacky");
    }
    public void GoCredits()
    {
        SceneManager.LoadScene("Credits");
    }
    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
