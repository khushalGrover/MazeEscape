using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class testPlayerController : MonoBehaviour
{
    public Camera cam;
    public UnityEngine.AI.NavMeshAgent agent;

    public NavMeshSurface surface;

    void Start()
    {
        surface = FindObjectOfType<NavMeshSurface>();
        if(surface == null)
        {
            Debug.Log("surface is null");
        }
        else
        {
            Debug.Log("surface is not null");
            surface.BuildNavMesh();
        }
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }
        }
    }
}
