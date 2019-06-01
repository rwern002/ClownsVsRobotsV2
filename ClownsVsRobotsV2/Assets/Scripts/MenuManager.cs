using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public bool paused = true;
    public bool gameStart = false;
    public bool gameLoss = false;
    public bool gameWin = false;
    public Transform canvas;
    public Transform MainMenu;
    public Transform UI;
    public Transform WinMenu;
    public Transform LossMenu;
    public GameObject player;
    public GameObject level;
    public int num_enemy_types;

    void Start()
    {
        UI.gameObject.SetActive(false);
        canvas.gameObject.SetActive(false);
        WinMenu.gameObject.SetActive(false);
        LossMenu.gameObject.SetActive(false);
        MainMenu.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if(!gameLoss && !gameWin)
        {
            if(Input.GetKeyDown("space") && !gameStart)
            {
                MainMenu.gameObject.SetActive(false);
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
                    Time.timeScale = 0;
                }
                else
                {
                    paused = false;
                    canvas.gameObject.SetActive(false);
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
        //loss condition
        if (player.GetComponent<PlayerHealth>().currentHealth <= 0 && gameStart && !gameLoss && !gameWin)
        {
            gameLoss = true;
            gameStart = false;
            paused = true;
            LossMenu.gameObject.SetActive(true);
            UI.gameObject.SetActive(false);
            Time.timeScale = 0;
        }
        if (Input.GetKeyDown("space") && gameLoss)
        {
            RestartGame();
            gameLoss = false;
        }
        if (!(level.GetComponent<spawnEnemy>().active) && gameStart && !gameLoss && !gameWin)
        {
            if (!isEnemy())
            {
                gameWin = true;
                gameStart = false;
                paused = true;
                WinMenu.gameObject.SetActive(true);
                UI.gameObject.SetActive(false);
                Time.timeScale = 0;
            }
        }
        if (Input.GetKeyDown("space") && gameWin)
        {
            RestartGame();
            gameWin = false;
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameStart = false;
        UI.gameObject.SetActive(false);
        canvas.gameObject.SetActive(false);
        WinMenu.gameObject.SetActive(false);
        LossMenu.gameObject.SetActive(false);
        MainMenu.gameObject.SetActive(true);
        Time.timeScale = 0;
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
