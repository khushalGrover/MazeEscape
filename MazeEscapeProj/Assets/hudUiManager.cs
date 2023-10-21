using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UIElements;

public class hudUiManager : MonoBehaviour
{
    
    [SerializeField]
    private GameObject miniMapUi, majorMapUi, mapUi;

    [SerializeField]
    private RectTransform rectTransform;

    private bool isMiniOpen, isMajorOpen;

    public void toggleMiniMap()
    {
        if (miniMapUi != null) 
        {
            Debug.Log(rectTransform.localScale + "brfore");
            isMiniOpen = isMiniOpen == true ? false : true;
            miniMapUi.SetActive(isMiniOpen);
            var scale = rectTransform.localScale;
            scale.x = 10;
            rectTransform.sizeDelta = scale;
            Debug.Log(rectTransform.localScale + "after");
        }
    }

    public void openMajorMap(bool isMapOpen)
    {
        

        if (miniMapUi != null)
        {
            Debug.Log(rectTransform.localScale + "brfore");
            // isMiniOpen = isMiniOpen == true ? false : true;
            // miniMapUi.SetActive(isMiniOpen);
            var scale = rectTransform.localScale;
            scale.x = isMapOpen ? 455 : 155;
            scale.y = isMapOpen ? 455 : 155;
            rectTransform.sizeDelta = scale;
            Debug.Log(rectTransform.localScale + "after");
        }


    }
    

}
