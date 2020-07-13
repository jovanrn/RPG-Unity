using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject referenca;

    public void PlayGame()
    {
        referenca.SetActive(true);


    }

    public void QuitGame()
    {
        Debug.Log("QUIT GAME");
        Application.Quit();
    }

  
}
 