using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hudUiManager : MonoBehaviour
{

    [SerializeField]
    private RectTransform rectTransform;

    public void openMajorMap(bool isMapOpen)
    {
        if (rectTransform != null)
        {
            var scale = rectTransform.localScale;
            scale.x = isMapOpen ? 455 : 155;
            scale.y = isMapOpen ? 455 : 155;
            rectTransform.sizeDelta = scale;
        }
    }
}
