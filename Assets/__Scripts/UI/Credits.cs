using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour {

	public void GoToMenu()
    {
        Debug.Log("Powrót do menu");
        SceneManager.LoadScene("MenuScene");
    }
}
