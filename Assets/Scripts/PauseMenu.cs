using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject player;

    public static bool GameIsPaused = false; 
    public GameObject pauseMenuUI;
    //public GameObject hudUI;

    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused) //kiedy klikamy esc ¿eby wyjœæ z pause menu
            {
                Resume(); Debug.Log("nie pauza");
            }
            else // kiedy klikamy esc ¿eby wyjœæ z gry
            {
                Pause(); Debug.Log("pauza");
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        player.GetComponent<FirstPersonController>().cameraCanMove = true;
        // hudUI.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;

        //Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        player.GetComponent<FirstPersonController>().cameraCanMove = false;
        // hudUI.SetActive(false); //gdy tego nie zrobie, panel w hud blokuje dostêp do buttonow 
        Time.timeScale = 0f;
        GameIsPaused = true;

        //Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    } 
    public void LoadMenu()
    {
        //Time.timeScale = 0f;
        Resume();
        SceneManager.LoadScene("MainMenu"); 
    }
    public void NewGame()
    {
        Resume();
        SceneManager.LoadScene("Level1"); 
    }
}
