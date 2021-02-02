using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    //starts game
    public void OnPlay()
    {
        SceneManager.LoadScene("Lvl1");
    }

    //exits out of application
    public void OnQuit()
    {
        Application.Quit();
    }

}
