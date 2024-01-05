using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField]
    private Vector2Int position;
    private GridManager gridMan;
    [SerializeField]
    private GameObject[] neighbours; //neighbours are organized in clockwise order, with 0 in the array being the top neighbour.
    private bool occupied;
    private GridObject occupying;
    void Start()
    {

    }

    void Update()
    {

    }

    public void SetGridManager(GridManager grid, Vector2Int position)
    {
        this.gridMan = grid;
        this.position = position;

    }
    public void SetNeighbours(GameObject[] neighbouring)
    {
        this.neighbours = neighbouring;
    }
    public Vector2Int GetPosition()
    {
        return position;
    }
    public bool GetOccupied()
    {
        return occupied;
    }
    public void SetOccupied(bool occupied, GridObject occupying = null)
    {
        this.occupied = occupied;  
        this.occupying = occupying;
    }
    public GridObject GetOccupying()
    {
        return occupying;
    }
}
