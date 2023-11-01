using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeCell : MonoBehaviour
{
    // Object references
    [SerializeField] private GameObject _frontWall;
    [SerializeField] private GameObject _leftWall;
    [SerializeField] private GameObject _unVisitedBlock;

    public bool IsVisited { get; private set; }

    public void Visit()
    {
        IsVisited = true;
        // _unVisitedBlock.SetActive(false);
        Destroy(_unVisitedBlock);
    }

    public void ClearLeftWall()
    {
        // _leftWall.SetActive(false);
        Destroy(_leftWall);
    }

    public void ClearFrontWall ()
    {
        // _frontWall.SetActive(false);
        Destroy(_frontWall);

    }

}
