using System.Collections;
using System.Collections.Generic;
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

    public void TempStartConstruction()
    {
        StartConstruction(selectedTile, new Vector3(0, 0, 0));
    }
    public void StartConstruction(Tile tile, Vector3 offset, GameObject constr = null,  bool both = false)
    {

        Vector3 spawnPos = tile.gameObject.transform.position + offset;
        construction.Add(tile);
        if (constr != null)
        {
            Instantiate(constr, spawnPos, Quaternion.identity);
            if (both)
            {
                uiman.SpawnConstruction(spawnPos);
            }
        }
        else
        {
            uiman.SpawnConstruction(spawnPos);
        }
    }
    public GridManager GetCurrentGrid(float height)
    {
        float overdiff = gridmanOverworld.gameObject.transform.position.y - height;
        float hivediff = gridmanHive.gameObject.transform.position.y - height;

        if (overdiff > hivediff)
            return gridmanHive;
        else
            return gridmanOverworld;
    }
}
