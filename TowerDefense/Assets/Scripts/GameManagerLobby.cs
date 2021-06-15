using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerLobby : MonoBehaviour
{
    
    public void StartGame()
    {
        SceneManager.LoadScene("Fase1");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
