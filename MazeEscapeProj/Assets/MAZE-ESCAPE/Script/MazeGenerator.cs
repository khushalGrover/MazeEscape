    
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class MazeGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject cellParent, borderCellParent;

    [SerializeField] 
    private GameObject enemySpawnPoint;

    [SerializeField]
    private MazeCell _mazeCellPrefab;

    [SerializeField]
    private GameObject borderCellPrefab, borderCell2Prefab;
    // private List<MazeCell> deadEnds = new List<MazeCell>();

    [SerializeField]
    private int _mazeCellSize;

    [SerializeField]
    private int _mazeWidth;

    [SerializeField]
    private int _mazeDepth;
    
    [SerializeField]
    private Vector3 offSet;


    private MazeCell[,] _mazeGrid;
    public NavMeshSurface _surface;

   

    void Start()
    {
        _mazeGrid = new MazeCell[_mazeWidth, _mazeDepth];
        
        
        #region Instantiate Maze cell (prefab) in recatangular block
            // rectangle grid is instantiate without bottom and right wall
            for (int x = 0; x < _mazeWidth; x+= _mazeCellSize)
            {
                for (int z = 0; z < _mazeDepth; z+=_mazeCellSize)
                {
                    _mazeGrid[x, z] = Instantiate(_mazeCellPrefab, new Vector3(x, _mazeCellSize/2, z)  , Quaternion.identity);
                    _mazeGrid[x,z].transform.parent = cellParent.transform; // change parent to clean Heriachy
                }
            }
    
            // both border wall instantiate
            for(int r=_mazeCellSize; r<_mazeWidth; r+=_mazeCellSize)
            {
                var tmpVar1 = Instantiate(borderCellPrefab, new Vector3(r, _mazeCellSize/2, -_mazeCellSize)  , Quaternion.Euler(0,0,0));
                tmpVar1.transform.parent = borderCellParent.transform; // change parent to clean Heriachy
            } 
            for(int c=0; c<_mazeDepth - _mazeCellSize; c+=_mazeCellSize)
            {
                
                var tmpVar2 = Instantiate(borderCell2Prefab, new Vector3(_mazeWidth, _mazeCellSize/2, c)  , Quaternion.Euler(0,0,0));
                tmpVar2.transform.parent = borderCellParent.transform; // change parent to clean Heriachy
            }
        #endregion   


        // Setting up the maze start point 
        GenerateMaze(null, _mazeGrid[0, 0]);

        // baking navmesh
        _surface = GetComponent<NavMeshSurface>();
        _surface.BuildNavMesh();
    }

    /// <summary>
    /// Generate maze recursively
    ///    1. visit current cell
    ///    2. clear wall between previous cell and current cell
    ///    3. get next unvisited cell
    ///    4. if next unvisited cell is not null, generate maze recursively
    /// </summary>
    /// <param name="previousCell"></param>
    /// <param name="currentCell"></param>
    private void GenerateMaze(MazeCell previousCell, MazeCell currentCell)
    {
        currentCell.Visit();
        ClearWalls(previousCell, currentCell);

        // yield return new WaitForSeconds(0.05f);

       // Check if the current cell is a dead end
        if (GetUnvisitedCells(currentCell).Count() == 0)
        {
            Vector3 offset = new Vector3(0, 0, 0);
            // deadEnds.Add(currentCell);
            // Spawn enemy at the dead end
            

            if(currentCell.IsLeftWall == false)
            {
                // Debug.Log("left wall is false");
                // Debug.Log(currentCell.transform.position);
                offSet = new Vector3(2.5f, 0, -2.5f);
            }
            SpawnEnemy(currentCell.transform.position + offSet);
        }


        for (MazeCell nextCells = GetNextUnvisitedCell(currentCell); nextCells != null; nextCells = GetNextUnvisitedCell(currentCell))
        {
            GenerateMaze(currentCell, nextCells);
        }
        

    }


    private void SpawnEnemy(Vector3 position)
    {
        // Instantiate your enemy at the specified position
        Instantiate(enemySpawnPoint, position, Quaternion.identity);
    }

    private MazeCell GetNextUnvisitedCell(MazeCell currentCell)
    {
        var unvisitedCells = GetUnvisitedCells(currentCell);
        // Debug.Log(unvisitedCells);
        return unvisitedCells.OrderBy(_ => Random.Range(1, 10)).FirstOrDefault();
    }

    /// <summary>
    /// Get unvisited cells around current cell
    ///    1. if current cell is on the right of previous cell, get right cell
    ///    2. if current cell is on the left of previous cell, get left cell
    ///    3. if current cell is on the front of previous cell, get front cell  
    ///    4. if current cell is on the back of previous cell, get back cell
    ///    5. if current cell is on the same position of previous cell, do nothing
    /// </summary>
    /// <param name="currentCell"></param>
    /// <returns></returns>
    private IEnumerable<MazeCell> GetUnvisitedCells(MazeCell currentCell)
    {
        #region 4 direction Original
        /*
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
        */
        #endregion
        
        #region 4 direction Optimized by ChatGPT
        int x = (int)currentCell.transform.position.x;
        int z = (int)currentCell.transform.position.z;
        int[,] directions = { 
            {  1 , 0 }, 
            { -1,  0 }, 
            {  0,  1 }, 
            {  0, -1 } 
        };

        for (int i = 0; i < 4; i++)
        {
            int newX = x + directions[i, 0] * _mazeCellSize;
            int newZ = z + directions[i, 1] * _mazeCellSize;

            if (newX >= 0 && newX < _mazeWidth && newZ >= 0 && newZ < _mazeDepth)
            {
                var adjacentCell = _mazeGrid[newX, newZ];
                if (!adjacentCell.IsVisited)
                {
                    // Instantiate(enemySpawnPoint, new Vector3(newX, 0f, newZ),  Quaternion.identity);
                    yield return adjacentCell;
                }
                
            }
            
        }
        #endregion
    }


    /// <summary>
    /// Clear wall between previous cell and current cell
    ///     1. if previous cell is null, do nothing
    ///     2. if current cell is on the right of previous cell, clear right wall of previous cell and left wall of current cell
    ///     3. if current cell is on the left of previous cell, clear left wall of previous cell and right wall of current cell
    ///     4. if current cell is on the front of previous cell, clear front wall of previous cell and back wall of current cell
    ///     5. if current cell is on the back of previous cell, clear back wall of previous cell and front wall of current cell
    ///     6. if current cell is on the same position of previous cell, do nothing
    /// </summary>
    /// <param name="previousCell"></param>
    /// <param name="currentCell"></param>
    private void ClearWalls(MazeCell previousCell, MazeCell currentCell)
    {
        if (previousCell == null)
        {
            return;
        }
        Vector3 positionDifference = currentCell.transform.position - previousCell.transform.position;
        switch (positionDifference)
        {
            case var diff when diff.x > 0:
                // previousCell.ClearRightWall();
                currentCell.ClearLeftWall();
                break;
            case var diff when diff.x < 0:
                previousCell.ClearLeftWall();
                // currentCell.ClearRightWall();
                break;
            case var diff when diff.z > 0:
                previousCell.ClearFrontWall();
                // currentCell.ClearBackWall();
                break;
            case var diff when diff.z < 0:
                // previousCell.ClearBackWall();
                currentCell.ClearFrontWall();
                break;
            
        }
    }

}
