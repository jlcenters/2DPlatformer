using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //what enemy is to move towards
    public Vector3 targetPosition;
    //where enemy will return to
    private Vector3 startPosition;

    public float moveSpeed;
    private bool movingToTargetPos;

    // Start is called before the first frame update
    void Start()
    {
        //setting start pos and confirming that enemy is moving to target
        startPosition = transform.position;
        movingToTargetPos = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(movingToTargetPos)
        {
            //current pos, target pos, distance per frame 
            // Time.deltaTime converts time to seconds rather than frames
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            if(transform.position == targetPosition)
            {
                movingToTargetPos = false;
            }
        }else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPosition, moveSpeed * Time.deltaTime);

            if(transform.position == startPosition)
            {
                movingToTargetPos = true;
            }
        }
    }

    //collision function
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //check by tag
        if(collision.gameObject.CompareTag("Player"))
        {
            //calls game over from player object
            collision.gameObject.GetComponent<Player>().GameOver();
        }
    }
}
