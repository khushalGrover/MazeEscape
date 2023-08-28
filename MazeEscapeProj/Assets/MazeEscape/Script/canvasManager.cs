using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class canvasManager : MonoBehaviour
{
    public static canvasManager instance;

    [SerializeField] private MyCenimaEffect myCenimaEffect;

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
   

    public void loadMenuScene()
    {
        SceneManager.LoadScene(0);

        // switch camera to give cinematic effect
        myCenimaEffect.SwitchToCamera(0);
    }

    public void loadFirstScene()
    {
        SceneManager.LoadScene(1);
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
    
        myCenimaEffect.SwitchToCamera(1);
        // pause/slow game
        Time.timeScale = 0.05f;

    }


    public void gameoverGame()
    {

        DeActivateAllPanel();
        
        Time.timeScale = 0f;        //freez the game include the user inputs and animations!!
        myCenimaEffect.SwitchToCamera(3);

    }

    public void resumeGame()
    {
        // Depactivate AND active Screen
        DeActivateAllPanel();
     
        myCenimaEffect.SwitchToCamera(0);

        // resume game
        hudPanel.SetActive(true);
        Time.timeScale = 1;
        
    }

    public void restartGame()
    {
        // reload current screen and deacivate all canvas...
        myCenimaEffect.SwitchToCamera(0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void option()
    {
        DeActivateAllPanel();
        optionPanel.SetActive(true);
        myCenimaEffect.SwitchToCamera(1);
    }
    
    public void credit()
    {
        DeActivateAllPanel();
        myCenimaEffect.SwitchToCamera(2);
        creditPanel.SetActive(true);
    }

    



}