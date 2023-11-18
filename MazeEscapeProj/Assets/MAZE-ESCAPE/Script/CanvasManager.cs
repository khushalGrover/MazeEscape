using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

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
    [SerializeField] private GameObject exitConfirmPanel;
    [SerializeField] private GameObject gameOverPanel;

    [Header("______Slider_____")]
    [SerializeField] private Slider healthSlider;
    [SerializeField] private RectTransform mapRectTransform;
    // [SerializeField] private MyCenimaEffect myCenimaEffect;
    private int currentSceneIndex;
    private void Awake()
    {
        // myCenimaEffect = gameObject.GetComponent<MyCenimaEffect>();
    }

    private void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

    }
    private void LateUpdate()
    {
        if (!Input.GetKeyUp(KeyCode.Escape)) return;

      
        if (currentSceneIndex != 0)
        {
            if (!pasuePanel.activeInHierarchy) pauseGame();
            else resumeGame();
        }
        else
        {
            if (!mainMenuHudPanel.activeInHierarchy) resumeMainMenu();
            else ExitConfirmPanel();
        }
    }




    public void DeActivateAllPanel()
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
        // myCenimaEffect.SwitchToCamera(2);

        GameManager.instance.UpdateGameState(GameState.Pause);
        // pause/slow game
        // Time.timeScale = 0.05f;
        // Cursor.lockState = CursorLockMode.None;
        // Cursor.visible = true;


    }

    public void ExitConfirmPanel()
    {
        DeActivateAllPanel();
        exitConfirmPanel.SetActive(true);
    }



    public void resumeGame()
    {
        // Deactivate AND active Screen
        DeActivateAllPanel();
        hudPanel.SetActive(true);

        
        GameManager.instance.UpdateGameState(GameState.Playing);

    }

    public void resumeMainMenu()
    {
        // Depactivate AND active Screen
        DeActivateAllPanel();
        mainMenuHudPanel.SetActive(true);
        

    }
    public void GameOver()
    {
        DeActivateAllPanel();
        gameOverPanel.SetActive(true);

        // Time.timeScale = 0f; //freez the game include the user inputs and animations!!
        //GameManager.instance.UpdateGameState(GameState.GameOver);
    }
    public void restartGame()
    {
        // reload current screen and deacivate all canvas...
        // myCenimaEffect.SwitchToCamera(0);
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameManager.instance.RestartScene();
        GameManager.instance.UpdateGameState(GameState.Playing);
    }

    public void option()
    {
        DeActivateAllPanel();
        optionPanel.SetActive(true);
        // myCenimaEffect.SwitchToCamera(2);
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
    public void updateHealthSlider(float health)
    {
        
        healthSlider.value = health;
        // update color of health slider
        if (healthSlider.value > 5 )
        {
            healthSlider.fillRect.GetComponent<Image>().color = Color.green;
        }
        else if (healthSlider.value > 3 && healthSlider.value <= 5)
        {
            healthSlider.fillRect.GetComponent<Image>().color = Color.yellow;
        }
        else if(healthSlider.value > 0)
        {
            healthSlider.fillRect.GetComponent<Image>().color = Color.red;
        }
    }


    


}
