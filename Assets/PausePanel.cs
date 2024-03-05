using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanel : MonoBehaviour
{
    public GameObject pause;
    private bool isPaused;
    public AudioSource audioSource;
    private void Start()
    {
        isPaused = false;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(isPaused){
                ResumeGame();
            }
            else{
                PauseGame();
            }
        }
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        isPaused = true;
        if(audioSource != null){
            audioSource.Pause();
        }

        if(pause != null){
            pause.SetActive(true);
        }
    }
    
    public void ResumeGame()
    {
        Time.timeScale = 1;
        isPaused = false;
        if(audioSource != null){
            audioSource.Play();
        }

        if (pause != null){
            pause.SetActive(false);
        }
    }
}
