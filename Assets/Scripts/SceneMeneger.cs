using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneMeneger : MonoBehaviour
{

    [SerializeField] private string NewGame;
    [SerializeField] private string Restart;
    [SerializeField] private string mainMenu;
    [SerializeField] private string developers;
    public void Retart()
    {
        SceneManager.LoadScene(Restart);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(NewGame);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }
    public void Level()
    {
        SceneManager.LoadScene(3);
    }

   
    public void MaxProger()
    {
        Application.OpenURL("https://t.me/dadGameDev");
    }

  
}
