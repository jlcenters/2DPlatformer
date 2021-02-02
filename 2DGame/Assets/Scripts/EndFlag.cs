using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndFlag : MonoBehaviour
{
    public bool finalLvl;
    public string nextScene;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(finalLvl)
            {
                SceneManager.LoadScene(0);
            } else
            {
                SceneManager.LoadScene(nextScene);
            }
        }
    }
}
