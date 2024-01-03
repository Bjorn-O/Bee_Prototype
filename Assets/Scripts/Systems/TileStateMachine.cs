using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileStateMachine : MonoBehaviour
{
    [SerializeField]
    private GridManager gridman;
    [SerializeField]
    private List<Tile> construction;
    [SerializeField]
    private UIManager uiman;
    private Tile selectedTile;

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
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity) && gridman.GetNearestTile(hit.point).GetComponent<Tile>() != null)
        {
            selectedTile = gridman.GetNearestTile(hit.point).GetComponent<Tile>();
            uiman.TileStats(selectedTile);
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
}
