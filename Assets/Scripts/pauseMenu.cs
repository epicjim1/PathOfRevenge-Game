using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class pauseMenu : MonoBehaviour
{
    public static bool paused;
    public GameObject PauseMenu;
    public GameObject player;
    public GameObject Animation;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(paused)
            {
                resume();
            }
            else
            {
                pause();
            }
        }
    }

    public void resume()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
        player.GetComponent<Shoot>().enabled = true;
    }

    void pause()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
        player.GetComponent<Shoot>().enabled = false;
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        var lvl2 = Animation.GetComponent<levelChanger>();
        lvl2.fadeToLevel(0);
    }

    public void Quit()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
