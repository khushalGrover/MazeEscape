using OpenCover.Framework.Model;
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

        // setting default state
        UpdateGameState(GameState.MainMenu);

    }

    public void UpdateGameState(GameState newState)
    {
        state = newState;

        switch(newState)
        {
            case GameState.MainMenu:
                break;

            case GameState.Playing:
                break;
            
            case GameState.Pause: 
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

    public void LoaderCallBack()
    {
        loader.LoaderCallback();
    }

    public void ToggleMap(bool mapOpen)
    {
        canvasManager.toggleMap(mapOpen);

    }
    #endregion

}
public enum GameState
{
    MainMenu,
    Playing,
    Pause,
    Victory,
    GameOver
}

