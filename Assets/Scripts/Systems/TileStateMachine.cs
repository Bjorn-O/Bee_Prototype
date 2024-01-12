using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TileStateMachine : MonoBehaviour
{
    [SerializeField]
    private GridManager gridmanOverworld, gridmanHive, currentGrid;
    [SerializeField]
    private List<Tile> construction;
    [SerializeField]
    private UIManager uiman;
    private Tile selectedTile;
    [SerializeField]
    private Camera overworldCam, hiveCam, currentCam;
    [SerializeField]
    private GameObject overworld, hive;
    private bool inHive;

    private void Start()
    {
        currentGrid = gridmanOverworld;
        currentCam = overworldCam;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TileCheck();
        }
    }

    private void TileCheck()
    {
        RaycastHit hit;
        Ray ray = currentCam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity) && currentGrid.GetNearestTile(hit.point).GetComponent<Tile>() != null)
        {
            selectedTile = currentGrid.GetNearestTile(hit.point).GetComponent<Tile>();
            uiman.TileStats(selectedTile);
            if (selectedTile.GetOccupied())
            {
                GridObject go = selectedTile.GetOccupying();
                if (go.GetInteractable())
                {
                     go.Interact();
                }
            }
        }
    }
    public void Transition(bool into)
    {
        overworld.SetActive(!into);
        hive.SetActive(into);
        overworldCam.enabled = !into;
        hiveCam.enabled = into;
        inHive = into;
        if(into)
        {
            currentCam = hiveCam;
            currentGrid = gridmanHive;
        }
        else
        {
            currentCam = overworldCam;
            currentGrid = gridmanOverworld;
        }
    }
    public Tile GetSelectedTile()
    {
        return selectedTile;
    }
    public void StartConstruction(GameObject tile, float time, GameObject constr = null,  bool both = false)
    {
        construction.Add(tile.GetComponent<Tile>());
        if (constr != null)
        {
            if (both)
            {
                uiman.SpawnClearing(tile, time); //overloads to be added to allow a different model for construction.
            }
        }
        else
        {
            uiman.SpawnClearing(tile, time); 
        }
    }
    public GridManager GetCurrentGrid(float height)
    {
        //returns the grid that the object should be snapped to.
        if (gridmanOverworld.gameObject.transform.position.y  >= height)
            return gridmanHive;
        else
            return gridmanOverworld;
    }
}
