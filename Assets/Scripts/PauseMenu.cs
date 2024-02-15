using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject player;

    public static bool GameIsPaused = false; 
    public GameObject pauseMenuUI;

    private void Start()
    {
        Cursor.visible = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused) //kiedy klikamy esc ¿eby wyjœæ z pause menu
            {
                Resume(); 
            }
            else // kiedy klikamy esc ¿eby wyjœæ z gry
            {
                Pause(); 
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        player.GetComponent<FirstPersonController>().cameraCanMove = true;
        Time.timeScale = 1f;
        GameIsPaused = false;

        Cursor.visible = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        player.GetComponent<FirstPersonController>().cameraCanMove = false;
        Time.timeScale = 0f;
        GameIsPaused = true;

        Cursor.visible = true;
    } 
    public void LoadMenu()
    {
        Time.timeScale = 0f;
        Resume();
        SceneManager.LoadScene("MainMenu"); 
    }
    public void NewGame()
    {
        Resume();
        SceneManager.LoadScene("Level1"); 
    }
}
