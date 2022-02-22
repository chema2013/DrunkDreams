using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class MainMenu : MonoBehaviour
{
    //loads a scene with the following name
    public void FirstLevel() {  
        SceneManager.LoadScene("FirstLevel");
    }

    public void  QuitGame()
    {
        Debug.Log("Quit Game");

        Application.Quit();
    }
}
