using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//for game over
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rig;
    public float jumpForce;
    public SpriteRenderer sr;
    public int score;
    public UI ui;

    //Fixed Update called at set time (physics best used with fixed)
    private void FixedUpdate()
    {
        //gets input on horiz axis 
        //left arrow and W and left joystick = -1
        //right arrow and D and right joystick = 1
        //neutral pos = 0
        float xInput = Input.GetAxis("Horizontal");

        //set Vector 2 for a 2D figure (x,y)
        //xInput * moveSpeed calculates where 
        //rig.velocity.y determines gravity
        rig.velocity = new Vector2(xInput * moveSpeed, rig.velocity.y);

    }

    // Update is called once per frame (0.02 sec)
    void Update()
    {
        //Look for up arrow or space btn press to trigger jump & verifies if player is grounded
        if((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)) && isGrounded())
        {
            //AddForce(force, mode)
            //ForceMode2D.Force = gradual force increase
            //ForceMode2D.Impulse = instant velocity
            rig.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        //checking if player is moving left or right; if left, the sprite img is flipped
        if(rig.velocity.x > 0)
        {
            sr.flipX = false;
        } else if(rig.velocity.x < 0)
        {
            sr.flipX = true;
        }
    }

    //checks if on ground
    bool isGrounded()
    {
        //pointer which checks 20 cm below the base of the player
        //3 values: position, direction, distance
        //add small margin between base and ground so that there are no collider errors
        RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(0,-0.1f,0), Vector2.down, 0.2f);
        
        //returns true if doesn't collide, returns false if collides
        return hit.collider != null;
    }

    //add score
    public void AddScore(int pts)
    {
        score += pts;
        ui.SetScoreTxt(score);
    }

    //reset scene upon game over
    public void GameOver()
    {
        //requires index of scene which to load
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
