using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI coordinates, occupied;
    [SerializeField]
    private GridManager gridman;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            TileStats();
        }
    }

    private void TileStats()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
           Tile tile = gridman.GetNearestTile(hit.point).GetComponent<Tile>();
            coordinates.text = "Coordinates: " + tile.GetPosition();
            occupied.text = "Occupied? " + tile.GetOccupied();
        }
    }
}
