using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class cameraManager : MonoBehaviour
{

    [SerializeField]
    private CinemachineVirtualCamera[] _vmCameras;

    [SerializeField] 
    private int _activeCameraIndex;

    private int _defaultCameraIndex;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
