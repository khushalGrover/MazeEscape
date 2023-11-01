using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MyCenimaEffect : MonoBehaviour
{

    public CinemachineVirtualCamera[] vCam;
    public int targetIndex=0;
    public int savedDefaultCameraIndex=0;

    private void SwitchToMainMenu()
    {
        // vCam[0].enabled = true;
        vCam[savedDefaultCameraIndex].enabled = true;
    }

    public void SwitchToCamera(int targetIndex)
    {
        
        // disabled all camera
        for (int i = 0; i < vCam.Length; i++)
        {
            vCam[i].enabled = false;
        }

        // enabled target vCam
        vCam[targetIndex].enabled = true;

    }

}
