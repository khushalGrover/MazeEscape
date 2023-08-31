using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeCell : MonoBehaviour
{
    // Object references
    [SerializeField] private GameObject _frontWall;
    // [SerializeField] private GameObject _rightWall;
    // [SerializeField] private GameObject _backWall;
    [SerializeField] private GameObject _leftWall;
    [SerializeField] private GameObject _unVisitedBlock;

    public bool IsVisited { get; private set; }

    public void Visit()
    {
        IsVisited = true;
        _unVisitedBlock.SetActive(false);
    }

    public void ClearLeftWall()
    {
        _leftWall.SetActive(false);
    }

    // public void ClearRightWall()
    // {
    //     _rightWall.SetActive(false);   
    // }

    public void ClearFrontWall ()
    {
        _frontWall.SetActive(false);
    }

    // public void ClearBackWall()
    // {
    //     _backWall.SetActive(false); 
    // }


}
