using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameState state;
    public static event Action<GameState> OnGameStateChanged;
   

    
    // reference variables
    private Loader loader;
    private CanvasManager canvasManager;
    private PlayerHealthManager playerHealthManager;
    private ZombieController zombieController;
    private MazeGenerator mazeGenerator;

    // getter and setter for zombie position
    public Vector3 zombiePosition
    {
        get => zombieController != null ? zombieController.transform.position : Vector3.zero;
        set
        {
            if (zombieController != null)
            {
                zombieController.transform.position = value;
            }
        }
    }



    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }


        // intialiize
        loader = gameObject.GetComponent<Loader>();
        canvasManager = gameObject.GetComponent <CanvasManager>();
        playerHealthManager = gameObject.GetComponent<PlayerHealthManager>();
        mazeGenerator = gameObject.GetComponent<MazeGenerator>();
        
        
        
        // setting default state
        // UpdateGameState(GameState.MainMenu);

    }

    public void UpdateGameState(GameState newState)
    {
        state = newState;

        switch(newState)
        {
            case GameState.MainMenu:
                // switch camera to give cinematic effect
                break;

            case GameState.Playing:
                HandlePlaying();
                break;
            
            case GameState.Pause: 
                HandlePause();
                break;

            case GameState.Victory: 
                break; 
            
            case GameState.GameOver: 
                HandleGameOver();
                break;
            
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        ///<Summary> this line of code triggers the event OnGameStateChanged 
        /// by calling any subscribed methods with the newState as an argument if the event is not null. 
        ///</Summary>
        OnGameStateChanged?.Invoke(newState);
    }

    private void HandlePlaying()
    {
        // canvasManager.resumeGame();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
        // myCenimaEffect.SwitchToCamera(0);
    }
    private void HandlePause()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    private void HandleGameOver()
    {
        canvasManager.GameOver();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    #region Load Scene Manager
    public void loadScene(int sceneIndex)
    {
        loader.Load(sceneIndex);

    }

    public void RestartScene()
    {
        loader.RestartScene();
    }

    public void LoaderCallBack()
    {
        loader.LoaderCallback();
    }

    #endregion
    // public void HandleToggleMap(bool mapOpen)
    // {
    //     canvasManager.toggleMap(mapOpen);

    // }



    #region Player Health Manager
    public void HurtPlayer(int damageToGive)
    {
        playerHealthManager.HurtPlayer(damageToGive);
        canvasManager.updateHealthSlider(playerHealthManager.playerCurrentHealth);
    }

    public void SetMaxHealth()
    {
        playerHealthManager.SetMaxHealth();
    }

    public void HealPlayer(int healAmount)
    {
        playerHealthManager.HealPlayer(healAmount);
    }

    public void UpdateHealthUI()
    {
        canvasManager.updateHealthSlider(playerHealthManager.playerCurrentHealth);
    }

    #endregion


    #region Zombie Health Manager
    
    #endregion


}
public enum GameState
{
    Default,
    MainMenu,
    Playing,
    Pause,
    MapOpen,
    MapClose,
    Victory,
    GameOver
}

