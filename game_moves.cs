//libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//class player_movement to dictate the movement of the player utilizing unity classes
public class Player_Movement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private bool isAI;
    [SerializeField] private GameObject ball; //AI to move with the ball 
    private Rigidbody2D rb;
    private Vector2 Player_Move;
    void Start(){ //start position
        rb = GetComponent<Rigidbody2D>();
    }
    void Update(){ //updates the position of player
        if (Input.GetKey("escape")){ //checks if player used the esc key to quit the game, then changes to escape menu
            Escape_Game();
        }
        if(isAI){ //checks if its AI and updates position
            AI_Control();
        } else { //checks if player, and updates position of paddle
            Player_Control();
        }
    }
    private void Escape_Game(){  //ends the game
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
    private void Player_Control(){ //input from player to move paddle
        Player_Move = new Vector2(0, Input.GetAxisRaw("Vertical"));
    }

    private void AI_Control(){
        if(ball.transform.position.y > transform.position.y + 0.5f){ //0.75 AI to move so it moves like a real player
            Player_Move = new Vector2(0,1);
        } 
        else if(ball.transform.position.y < transform.position.y - 0.5f){
            Player_Move = new Vector2(0,-1); //reaction to ball move
        } else {
            Player_Move = new Vector2(0,0); //reaction to ball move
        }
    }
    private void FixedUpdate(){
        rb.velocity = Player_Move * movementSpeed; //bettter version of the update function
    }
}
