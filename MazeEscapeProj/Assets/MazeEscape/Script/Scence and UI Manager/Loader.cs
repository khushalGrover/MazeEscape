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

    public void Load(int sceneIndex)
    {
        // Set the loader callback action to load the target scene
        onLoaderCallback = () => {
            SceneManager.LoadScene(sceneIndex);
        };

        // Load the Loading Scene
        LoadLoading();
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(SceneName.Main_Menu.ToString());
    }

    public void LoadLoading()
    {
        SceneManager.LoadScene(SceneName.Loading.ToString());
    }

    public void LoadNextScene()
    {
        int nextIndex = (SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(++nextIndex);

    }
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
