using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{

    [SerializeField]
    private RectTransform rectTransform;

    [SerializeField]
    private CinemachineVirtualCamera[] _vmCameras;

    [SerializeField] 
    private int _activeCameraIndex;

    private int _defaultCameraIndex;

    

    public void toggleMap(bool isMapOpen)
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
