//libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Pause_Menu : MonoBehaviour //pause menu function to show display 
{
    public static bool gameIsPaused = false; //seeing if game is paused
    public GameObject PauseMenuUI; //calls gameobject for the pause menu
    void Update(){
        if(Input.GetKeyDown(KeyCode.Tab)){ //checks if player wants to pause game
            if(gameIsPaused){
                Resume(); //if already paused, play game
            } else {
                Pause(); //if not paused then pause game
            }
        } 
    }
    public void Resume(){ //begins game again
        PauseMenuUI.SetActive(false);
        gameIsPaused = false;
        Time.timeScale = 1f;
    }
    public void Pause(){ //pauses game 
        PauseMenuUI.SetActive(true);
        gameIsPaused = true;
        Time.timeScale = 0f;
    }
}


