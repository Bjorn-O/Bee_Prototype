using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridObject : MonoBehaviour
{
    [SerializeField]
    private GridManager grid;
    private Vector3 lastPos;
    private Tile tile;
    [SerializeField]
    private bool Interactable;

    protected virtual void Start()
    {
        grid = GameObject.FindGameObjectWithTag("TSM").GetComponent<TileStateMachine>().GetCurrentGrid(this.gameObject.transform.position.y); //kinda a stupid thing, but if it works it works.
        Snap();
        lastPos = gameObject.transform.position;
    }
   protected virtual void Update()
    { 
        if(grid == null)
        {
            grid = GameObject.FindGameObjectWithTag("TSM").GetComponent<TileStateMachine>().GetCurrentGrid(this.gameObject.transform.position.y);
            return;
        }
        //if object is moved, start snapping it to the grid again.
        if (lastPos != gameObject.transform.position && grid != null)
        {
            Snap();
        }
      lastPos = gameObject.transform.position;
    }

    private void Snap()
    {
        transform.position = grid.SnapPosition(gameObject.transform.position.x, gameObject.transform.position.z, this);
    }
    public Tile GetCurrentTile()
    {
        if(tile!=null)
        return tile.GetComponent<Tile>();
        else
            return null;
    }
    public void SetCurrentTile(Tile T)
    {
        tile = T;
    }
    public bool GetInteractable()
    {
        return Interactable;
    }

    public virtual void Interact()
    {
        Debug.Log("Didn't override the original function.");
        /*
         * my intention for this function is for it to be overridden in any children, so that scripts only need a reference to the gridobject to activate any Interaction.
         */
    }
}
