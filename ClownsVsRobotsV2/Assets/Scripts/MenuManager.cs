using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    bool paused = true;
    bool gameStart = false;
    public Transform canvas;
    public Transform MainMenu;
    public Transform UI;
    void Start()
    {
        UI.gameObject.SetActive(false);
        MainMenu.gameObject.SetActive(true);
        canvas.gameObject.SetActive(false);
        Cursor.visible = true;
        Time.timeScale = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space") && !gameStart)
        {
            MainMenu.gameObject.SetActive(false);
            Cursor.visible = false;
            UI.gameObject.SetActive(true);
            Time.timeScale = 1;
            gameStart = true;
        }
        if (Input.GetKeyDown("space") && gameStart)
        {
            if (paused == false)
            {
                paused = true;
                canvas.gameObject.SetActive(true);
                Cursor.visible = true;
                Time.timeScale = 0;
            }
            else
            {
                paused = false;
                canvas.gameObject.SetActive(false);
                Cursor.visible = false;
                Time.timeScale = 1;
            }
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (paused && gameStart)
            {
                RestartGame();
            }
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameStart = false;
        UI.gameObject.SetActive(false);
        MainMenu.gameObject.SetActive(true);
        canvas.gameObject.SetActive(false);
        Cursor.visible = true;
        Time.timeScale = 0;
    }
}
