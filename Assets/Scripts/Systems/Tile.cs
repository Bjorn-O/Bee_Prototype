using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{

    private int x, y;
    private GridManager gridMan;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetGridManager(GridManager grid, int xPos, int yPos)
    {
        this.gridMan = grid;
        this.x = xPos;
        this.y = yPos;

    }
    
}
