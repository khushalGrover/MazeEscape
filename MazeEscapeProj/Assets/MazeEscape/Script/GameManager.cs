using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
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
        loader = gameObject.GetComponent<Loader>();
        canvasManager = gameObject.GetComponent <CanvasManager>();

    }

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




}
