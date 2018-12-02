using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        Debug.Log("Ładowanie Sceny");
        SceneManager.LoadScene("ScenaTestowa");
    }
	
    public void ExitGame()
    {
        Debug.Log("Wyłączenie aplikacji");
        Application.Quit();
    }

}
