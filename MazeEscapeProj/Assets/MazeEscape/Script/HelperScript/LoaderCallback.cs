using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderCallback : MonoBehaviour
{
    private bool isFirstUpdate = true;

    public void Update()
    {
        if(isFirstUpdate)
        {
            isFirstUpdate = false;
            GameManager.instance.LoaderCallBack();
        }
    }
}
