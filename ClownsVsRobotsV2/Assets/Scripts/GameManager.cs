using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject UIcanvas;
    public GameObject PauseScreen;
    public GameObject StartScreen;
    public GameObject LossScreen;
    public GameObject WinScreen;
    public GameObject ControlScreen;
    public GameObject player;
    public GameObject level;
    public bool gameStart = false;
    public bool paused = false;


    // Start is called before the first frame update
    void Start()
    {
        StartScreen.SetActive(true);
        ControlScreen.SetActive(false);
        PauseScreen.SetActive(false);
        WinScreen.SetActive(false);
        LossScreen.SetActive(false);
        UIcanvas.SetActive(false);
        Time.timeScale = 0.0f; 

        
    }

    public void startGame()
    {
        StartScreen.SetActive(false);
        gameStart = true;
        Time.timeScale = 1.0f;
        UIcanvas.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void helpMenu()
    {
        StartScreen.SetActive(false);
        ControlScreen.SetActive(true);
    }

    public void mainMenu()
    {
        StartScreen.SetActive(true);
        ControlScreen.SetActive(false);
    }

    public void restartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void endGame()
    {
        #if UNITY_EDITOR
          UnityEditor.EditorApplication.isPlaying = false;
        #else
          Application.Quit();
        #endif
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;
        paused = false;
        PauseScreen.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Pause()
    {
        Time.timeScale = 0.0f;
        paused = true;
        PauseScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void nextWave()
    {
        WinScreen.SetActive(false);
        UIcanvas.SetActive(true);
        Time.timeScale = 1.0f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.GetComponent<PlayerHealth>().currentHealth <= 0)
        {
            LossScreen.SetActive(true);
            UIcanvas.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if (!(level.GetComponent<spawnEnemy>().active))
        {
            if (!isEnemy())
            {
                WinScreen.SetActive(true);
                UIcanvas.SetActive(false);
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && gameStart == true)
        {
            if(paused == true)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    bool isEnemy()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("enemy");
        Debug.Log("Num enemies" + objects.Length);
        if (objects.Length > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
