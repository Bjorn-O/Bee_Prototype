using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI coordinates, occupied;
    [SerializeField]
    private GameObject constructionElement;
    [SerializeField]
    private GridManager gridman;
    [SerializeField]
    private Canvas screenSpace, worldSpace;
    

    public void TileStats(Tile tile)
    {
      coordinates.text = "Coordinates: " + tile.GetPosition();
      occupied.text = "Occupied? " + tile.GetOccupied();
    }

    public void SpawnConstruction(Vector3 position)
    {
        Vector3 offset = new Vector3(0, 1, 0);
       GameObject constr = Instantiate(constructionElement, position + offset,  Quaternion.identity);
        constr.transform.SetParent(worldSpace.gameObject.transform);
        constr.transform.Rotate(90, 0, 0);
        constr.transform.position = position + offset;
    }
    
}
