using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointDoorManager : MonoBehaviour
{
    
    // enum for start and end point
    public Point point;
    public GameObject door;

    private void Start()
    {
        if (point == Point.Start)
        {
            door.SetActive(true);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (point != Point.Start)
            {
                return;
            }
            
            // open the door by roating smootly 90 degree
            door.transform.Rotate(0, 90, 0);
            Debug.Log("Door Open");
        }
    }
    
}

public enum Point
{
    Start,
    End
}
