using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class canvasManager : MonoBehaviour
{
    public static canvasManager instance;

    // [Header("_______Joysticks________")]
    // [Tooltip("Joysticks")]
    // public Joystick leftJoystick;
    // public Joystick rightJoystick;

    [Header("______Canvas_____")]
    [Tooltip("Canvas")]

    [SerializeField] private GameObject hudPanel;
    [SerializeField] private GameObject pasuePanel;
    [SerializeField] private GameObject creditPanel;
    [SerializeField] private GameObject optionPanel;
    [SerializeField] private GameObject gameOverPanel;
    // [SerializeField] private GameObject exitConfirmPanel;

   

    private void Start()
    {
        // if(SceneManager.GetActiveScene().buildIndex == 1)
        // {
        //     DeActivateAllPanel();
        // }

        resumeGame();
    }

   void DeActivateAllPanel()
    {
        hudPanel.SetActive(false);
        pasuePanel.SetActive(false);
        creditPanel.SetActive(false);
        optionPanel.SetActive(false);
        gameOverPanel.SetActive(false);

    }
   

    public void loadMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void loadFirstScene()
    {
        SceneManager.LoadScene(1);
        Debug.Log("trying to load");
    }
    public void loadSecondScene()
    {
        SceneManager.LoadScene(2);
    }
    public void APPQUIT()
    {
        Application.Quit();
    }

    public void pauseGame()
    {
        // activate AND deactive screen 
        DeActivateAllPanel();
        pasuePanel.SetActive(true);
    
        // pause/slow game
        Time.timeScale = 0.05f;

    }

    public void gameOver()
    {

        DeActivateAllPanel();

        Time.timeScale = 0f;

    }

    public void resumeGame()
    {
        // Depactivate AND active Screen
        DeActivateAllPanel();
     
        // resume game
        hudPanel.SetActive(true);
        Time.timeScale = 1;
        
    }

    public void option()
    {
        DeActivateAllPanel();
        optionPanel.SetActive(true);
        Debug.Log("Option button press");
    }
    
    public void credit()
    {
        DeActivateAllPanel();
        creditPanel.SetActive(true);
        Debug.Log("Option button press");
    }

    public void restartGame()
    {
        // reload current screen and deacivate all canvas...
       
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }



}