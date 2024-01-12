using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Xml;
using Unity.VisualScripting;
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
        tiles = new GameObject[size, size];
        GenerateGrid();

    }
    public void GetGridPosition(float x, float z)
    {
        Vector3 position = new Vector3(x, 0, z);
        grid.LocalToCell(position);
    }
    public GameObject GetNearestTile(Vector3 position)
    {
        Vector3Int pos = grid.LocalToCell(position);
        Debug.Log(pos.x + "," + pos.y);
        return tiles[pos.x, pos.y];
    }
    public Vector3 SnapPosition(float x, float z, GridObject go)
    {
        // translate the position into a vector3. then get the closest cell in the grid to it. Check if said cell is initialized. Then snap the object to it, and notify the tile that it is now occupied.
        Vector3 position = new Vector3(x, this.transform.position.y, z);
        Vector3Int cellPos = grid.LocalToCell(position);
        if (tiles[cellPos.x, cellPos.y] != null)
        {
            SetTile(go, tiles[cellPos.x, cellPos.y].GetComponent<Tile>());
            return grid.CellToLocal(grid.LocalToCell(position)); //there is something inherently hilarious about this line of code to me. getting the closest tile from a position, just to get the position from that tile.
        }
        else
        {
            return position;
        }
    }

    private void SetTile(GridObject go, Tile t)
    {
        Tile currentTile = go.GetCurrentTile();
        
        if(currentTile != null)
        {
            currentTile.SetOccupied(false);
        }
        t.SetOccupied(true, go);
        go.SetCurrentTile(t);
    }

    private void GenerateGrid()
    {
        for (int v = 0; v < size; v++)
        {
            for (int h = 0; h < size; h++)
            {
                Vector3Int tileIndex = new Vector3Int(v, h, 0);
                Tile instTile = Instantiate(tile, grid.CellToLocal(tileIndex), Quaternion.identity).GetComponent<Tile>();
                instTile.SetGridManager(this, new Vector2Int(v,h));
                instTile.gameObject.transform.parent = grid.gameObject.transform;
                Transform trans = instTile.gameObject.transform;
                trans.position = new Vector3(trans.position.x, this.gameObject.transform.position.y, trans.position.z);
                tiles[v, h] = instTile.gameObject; //throw the tile objects into the array. this should have the same index as the actual tile in the grid.

            }
        }

        foreach(GameObject t in tiles)
        {
            Tile currentTile = t.GetComponent<Tile>();
            Vector2Int pos = currentTile.GetPosition();
            GameObject[] currentNeighbours = new GameObject[6];

            /*
             * tbh not too happy about this function, if you have a better way of doing this, let me know -Ricardo
               
                This function hands the neighbours to the tile so that each tile may know of their neighbours.
                it does so in clockwise order, with 0 being top, and moving right from there.
            */

            if(pos.x + 1 < size)
            {
                currentNeighbours[0] = tiles[pos.x + 1, pos.y];
                if(pos.y + 1 < size)
                {
                    currentNeighbours[1] = tiles[pos.x , pos.y + 1];

                }
                if(pos.y -1 >= 0)
                {
                    currentNeighbours[5] = tiles[pos.x, pos.y - 1];

                }
            }
                if(pos.y + 1 < size && pos.x - 1 >= 0)
            {
                currentNeighbours[2] = tiles[pos.x-1, pos.y + 1];

            }


            if (pos.x - 1 >= 0 )
            {
                currentNeighbours[3] = tiles[pos.x - 1, pos.y];
                if (pos.y - 1 >= 0)
                {

                    currentNeighbours[4] = tiles[pos.x - 1, pos.y - 1];
                }
    
            }

            currentTile.SetNeighbours(currentNeighbours);
        }
    }
}
