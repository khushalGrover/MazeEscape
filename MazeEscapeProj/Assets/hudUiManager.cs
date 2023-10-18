using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hudUiManager : MonoBehaviour
{
    
    [SerializeField]
    private GameObject miniMapUi, majorMapUi, mapUi;

    private bool isMiniOpen, isMajorOpen;

    public void toggleMiniMap()
    {
        if (miniMapUi != null) 
        {
            isMiniOpen = isMiniOpen == true ? false : true;
            miniMapUi.SetActive(isMiniOpen);
        }
    }

    public void openMajorMap(bool isMajorOpen)
    {
        if(majorMapUi != null)
        {
            // isMajorOpen = isMajorOpen == true ? false : true;
            majorMapUi.SetActive(isMajorOpen);
        }
        
        
    }
    

}
