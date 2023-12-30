using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Xml;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField]
    private Grid grid;
    [SerializeField]
    private int size;
    [SerializeField]
    private GameObject tile;
    private GameObject[,] tiles;

    private void Start()
    {
        tiles = new GameObject[size,size];
        GenerateGrid();
        
    }
    public void GetGridPosition(float x, float z)
    {
        Vector3 position = new Vector3(x, 0, z);
        grid.LocalToCell(position);
    }
    public Vector3 SnapPosition(float x, float z)
    {
        Vector3 position = new Vector3(x, 0, z);
        return grid.CellToLocal(grid.LocalToCell(position)); //there is something inherently hilarious about this line of code to me. getting the closest tile from a position, just to get the position from that tile.
    }

    private void GenerateGrid()
    {
        for (int v = 0; v < size; v++)
        {
            for (int h = 0; h < size; h++)
            {
                Vector3Int tileIndex = new Vector3Int(v, h, 0);
               tiles[v,h] = Instantiate(tile, grid.CellToLocal(tileIndex), Quaternion.identity); //throw the tile objects into the array. this should have the same index as the actual tile in the grid. testing still.

            }
        }
    }
}
