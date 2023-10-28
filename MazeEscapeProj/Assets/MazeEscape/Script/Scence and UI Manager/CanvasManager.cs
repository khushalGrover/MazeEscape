using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager instance;

    // [SerializeField] private MyCenimaEffect myCenimaEffect;

    [Header("______Canvas_____")]
    [Tooltip("Canvas")]
    [SerializeField] private GameObject hudPanel;
    [SerializeField] private GameObject mainMenuHudPanel;
    [SerializeField] private GameObject pasuePanel;
    [SerializeField] private GameObject creditPanel;
    [SerializeField] private GameObject optionPanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private RectTransform mapRectTransform;

  
    private void LateUpdate()
    {

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (!pasuePanel.activeInHierarchy)
            {
                pauseGame();
                
            }
            
        }
        
        Debug.Log(Cursor.lockState + "  " + Cursor.visible.ToString());

    }



    private void Start()
    {
    }

    void DeActivateAllPanel()
    {
        hudPanel.SetActive(false);
        mainMenuHudPanel.SetActive(false);
        pasuePanel.SetActive(false);
        creditPanel.SetActive(false);
        optionPanel.SetActive(false);
        gameOverPanel.SetActive(false);

    }


    public void loadMenuScene()
    {
        // SceneManager.LoadScene(0);
        GameManager.instance.loadScene(0);

        // switch camera to give cinematic effect
        // myCenimaEffect.SwitchToCamera(0);
    }

    public void loadFirstScene()
    {
        // SceneManager.LoadScene(1);
        GameManager.instance.loadScene(1);

    }

    public void loadSecondScene()
    {
        // SceneManager.LoadScene(2);
        GameManager.instance.loadScene(2);

    }

    public void APPQUIT()
    {
        Application.Quit();
    }

    public void pauseGame()
    {
        // TODO Disable input 

        // activate AND deactive screen 
        DeActivateAllPanel();
        pasuePanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        // myCenimaEffect.SwitchToCamera(2);
        // pause/slow game
        // Time.timeScale = 0.05f;

    }


    public void gameoverGame()
    {

        DeActivateAllPanel();

        Time.timeScale = 0f;        //freez the game include the user inputs and animations!!
        // myCenimaEffect.SwitchToCamera(3);

    }

    public void resumeGame()
    {
        // Depactivate AND active Screen
        DeActivateAllPanel();

        // myCenimaEffect.SwitchToCamera(0);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        // resume game
        hudPanel.SetActive(true);
        Time.timeScale = 1;

    }

    public void resumeMainMenu()
    {
        // Depactivate AND active Screen
        DeActivateAllPanel();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        mainMenuHudPanel.SetActive(true);

    }

    public void restartGame()
    {
        // reload current screen and deacivate all canvas...
        // myCenimaEffect.SwitchToCamera(0);
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameManager.instance.RestartScene();
    }

    public void option()
    {
        DeActivateAllPanel();
        optionPanel.SetActive(true);
        // myCenimaEffect.SwitchToCamera(1);
    }

    public void credit()
    {
        DeActivateAllPanel();
        // myCenimaEffect.SwitchToCamera(2);
        creditPanel.SetActive(true);
    }

    public void cameraToWatch()
    {
        // myCenimaEffect.SwitchToCamera(3);
    }
    public void toggleMap(bool isMapOpen)
    {
        if (mapRectTransform != null)
        {
            var scale = mapRectTransform.localScale;
            scale.x = isMapOpen ? 455 : 155;
            scale.y = isMapOpen ? 455 : 155;
            mapRectTransform.sizeDelta = scale;
        }
    }




}
