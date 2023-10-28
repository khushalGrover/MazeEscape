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
    // private MyCenimaEffect myCenimaEffect;


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
        //myCenimaEffect = gameObject.GetComponent<MyCenimaEffect>();
        
        
        // setting default state
        // UpdateGameState(GameState.MainMenu);

    }

    public void UpdateGameState(GameState newState)
    {
        state = newState;

        switch(newState)
        {

            case GameState.Default:
                Debug.Log("Default");
                break;

            case GameState.MainMenu:
                // switch camera to give cinematic effect
                // myCenimaEffect.SwitchToCamera(0);
                break;

            case GameState.Playing:
                HandleToggleMap(false);
                break;
            
            case GameState.Pause: 
                break;
                
            case GameState.MapOpen:
                HandleToggleMap(true);
                break;

            case GameState.Victory: 
                break; 
            
            case GameState.GameOver: 
                break;
            
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        ///<Summary> this line of code triggers the event OnGameStateChanged 
        /// by calling any subscribed methods with the newState as an argument if the event is not null. 
        ///</Summary>
        OnGameStateChanged?.Invoke(newState);
        Debug.Log("current state is " +  newState);
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

    public void HandleToggleMap(bool mapOpen)
    {
        canvasManager.toggleMap(mapOpen);

    }
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

