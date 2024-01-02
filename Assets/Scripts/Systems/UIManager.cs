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

    public void TileStats(Tile tile)
    {

            coordinates.text = "Coordinates: " + tile.GetPosition();
            occupied.text = "Occupied? " + tile.GetOccupied();
        }
    }


}
