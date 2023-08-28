using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MyCenimaEffect : MonoBehaviour
{

    public CinemachineVirtualCamera[] vCam;
    public int targetIndex=0;

    public void SwitchToMainMenu()
    {
        vCam[0].enabled = true;
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
