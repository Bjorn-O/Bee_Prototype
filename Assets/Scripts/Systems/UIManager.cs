using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI coordinates, occupied, clearCost, clearTime;
    [SerializeField]
    private GameObject constructionElement, clearingButton, clearingElement, selectedTile;
    private float selectedTime;
    [SerializeField]
    private GridManager gridman;
    [SerializeField]
    private Canvas screenSpace, worldSpace;
    

    public void TileStats(Tile tile)
    {
      coordinates.text = "Coordinates: " + tile.GetPosition();
      occupied.text = "Occupied? " + tile.GetOccupied();
    }

    public void SpawnConstruction(GameObject tile, float time)
    {
        Vector3 offset = new Vector3(0, 1, 0);
        Vector3 position = tile.transform.position;

       GameObject constr = Instantiate(constructionElement, position + offset,  Quaternion.identity);
        constr.transform.SetParent(worldSpace.gameObject.transform);
        constr.transform.Rotate(90, 0, 0);
        constr.transform.position = position + offset;
    }

    public void SpawnClearing(GameObject tile, float time)
    {
        Debug.Log("Spawning clearing");
        selectedTile = tile;
        selectedTime = time;
        clearingButton.SetActive(true);
        clearCost.text = "Costs: " + " None yet";
        clearTime.text =  time > 60 ? "Time to clear :" + time / 60 + " Minutes" : "Time to clear :" + time + " seconds"; 

    }
    public void StartClearing()
    {
        GameObject Timer = Instantiate(clearingElement, selectedTile.gameObject.transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
        Timer.transform.parent = worldSpace.transform;
        Timer.transform.Rotate(90, 0, 0);
        Timer.GetComponent<ClearRubble>().StartTimer(selectedTime, selectedTile);
        selectedTile = null;
        selectedTime = 0;
    }

    public float GetSelectedTime()
    {
        return selectedTime;
    }
}
