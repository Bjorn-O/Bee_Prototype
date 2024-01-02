using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField]
    private GridManager gridman;
    [SerializeField]
    private Tile[] construction;
    [SerializeField]
    private UIManager uiman;

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
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            Tile tile = gridman.GetNearestTile(hit.point).GetComponent<Tile>();
            uiman.TileStats(tile);
        }
    }
}
