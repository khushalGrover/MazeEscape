using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    public int sceneIndex;

    private static Action onLoaderCallback;
    public enum SceneName
    {
        Main_Menu,
        Loading,
    }

    private void Awake()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }




    public void Load(int sceneIndex)
    {
        // Set the loader callback action to load the target scene
        onLoaderCallback = () => {
            SceneManager.LoadScene(sceneIndex);
        };

        // Load the Loading Scene
        LoadLoading();
    }

   
    public void LoadLoading()
    {
        SceneManager.LoadScene(SceneName.Loading.ToString());
    }

  
    public void RestartScene()
    {
        // Set the loader callback action to load the target scene
        /*onLoaderCallback = () => {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        };*/

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        // Load the Loading Scene
        // LoadLoading();
    }


    public void LoaderCallback()
    {
        // Execute the Loader callback actions which will load the target scene
        if (onLoaderCallback != null)
        {
            onLoaderCallback();
            onLoaderCallback = null;
        }
    }
}
