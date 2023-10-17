
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    [SerializeField]
    private MazeCell _mazeCellPrefab;

    [SerializeField]
    private int _mazeCellSize;

    [SerializeField]
    private int _mazeWidth;

    [SerializeField]
    private int _mazeDepth;
    
    [SerializeField]
    private Vector3 offSet;

    [SerializeField]
    private GameObject borderCell, borderCell2;

    private MazeCell[,] _mazeGrid;

    void Start()
    {
        _mazeGrid = new MazeCell[_mazeWidth, _mazeDepth];
        
        // rectangle grid is instantiate without bottom and right wall
        for (int x = 0; x < _mazeWidth; x+=_mazeCellSize)
        {
            for (int z = 0; z < _mazeDepth; z+=_mazeCellSize)
            {
                _mazeGrid[x, z] = Instantiate(_mazeCellPrefab, new Vector3(x, 15, z * offSet.z)  , Quaternion.identity);
                Debug.Log(_mazeGrid[x, z].transform.position);
            }
        }
        // both border wall instantiate
        for(int r=0; r<_mazeWidth; r+=_mazeCellSize)
        {
            Instantiate(borderCell, new Vector3(r, 0, 0)  , Quaternion.Euler(0,180,0));
        } 
        for(int c=0; c<_mazeDepth; c+=_mazeCellSize)
        {
            Instantiate(borderCell2, new Vector3(_mazeWidth, 0, c)  , Quaternion.Euler(0,-90,0));

        }




        GenerateMaze(null, _mazeGrid[0, 0]);
    }

    private void GenerateMaze(MazeCell previousCell, MazeCell currentCell)
    {
        currentCell.Visit();
        ClearWalls(previousCell, currentCell);

        // yield return new WaitForSeconds(0.05f);

        MazeCell nextCell;

        do
        {
            nextCell = GetNextUnvisitedCell(currentCell);

            if (nextCell != null)
            {
                GenerateMaze(currentCell, nextCell);
            }
        } while (nextCell != null);
    }

    private MazeCell GetNextUnvisitedCell(MazeCell currentCell)
    {
        var unvisitedCells = GetUnvisitedCells(currentCell);

        return unvisitedCells.OrderBy(_ => Random.Range(1, 10)).FirstOrDefault();
    }

    private IEnumerable<MazeCell> GetUnvisitedCells(MazeCell currentCell)
    {
        int x = (int)currentCell.transform.position.x ;
        int z = (int)currentCell.transform.position.z ;

        if (x + _mazeCellSize < _mazeWidth)
        {
            var cellToRight = _mazeGrid[x + _mazeCellSize, z];

            if (cellToRight.IsVisited == false)
            {
                yield return cellToRight;
            }
        }

        if (x - _mazeCellSize >= 0)
        {
            var cellToLeft = _mazeGrid[x - _mazeCellSize, z];

            if (cellToLeft.IsVisited == false)
            {
                yield return cellToLeft;
            }
        }

        if (z + _mazeCellSize < _mazeDepth)
        {
            var cellToFront = _mazeGrid[x, z + _mazeCellSize];

            if (cellToFront.IsVisited == false)
            {
                yield return cellToFront;
            }
        }

        if (z - _mazeCellSize >= 0)
        {
            var cellToBack = _mazeGrid[x, z - _mazeCellSize];

            if (cellToBack.IsVisited == false)
            {
                yield return cellToBack;
            }
        }
    }


    // clear wall 
    private void ClearWalls(MazeCell previousCell, MazeCell currentCell)
    {
        if (previousCell == null)
        {
            return;
        }

        if (previousCell.transform.position.x < currentCell.transform.position.x)
        {
            // previousCell.ClearRightWall();
            currentCell.ClearLeftWall();
            return;
        }

        if (previousCell.transform.position.x > currentCell.transform.position.x)
        {
            previousCell.ClearLeftWall();
            // currentCell.ClearRightWall();
            return;
        }

        if (previousCell.transform.position.z < currentCell.transform.position.z)
        {
            previousCell.ClearFrontWall();
            // currentCell.ClearBackWall();
            return;
        }

        if (previousCell.transform.position.z > currentCell.transform.position.z)
        {
            // previousCell.ClearBackWall();
            currentCell.ClearFrontWall();
            return;
        }
    }

}
