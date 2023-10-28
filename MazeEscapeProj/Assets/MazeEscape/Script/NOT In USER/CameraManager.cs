using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{

    [SerializeField]
    private CinemachineVirtualCamera[] _vmCameras;

    [SerializeField] 
    private int _activeCameraIndex;

    private int _defaultCameraIndex;

}
