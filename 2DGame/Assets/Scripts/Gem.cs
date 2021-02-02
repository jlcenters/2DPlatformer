using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    public int value = 1;

    //checks if collision is w player, adds points to score, destroys gem
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().AddScore(value);
            Destroy(gameObject);
            Debug.Log("added score");
        }
    }
}
