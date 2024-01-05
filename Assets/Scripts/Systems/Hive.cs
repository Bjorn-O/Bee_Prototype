using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hive : GridObject
{
    private TileStateMachine tsm;
    [SerializeField]
    private bool overworld; 
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        tsm = GameObject.FindGameObjectWithTag("TSM").GetComponent<TileStateMachine>();
    }

    protected override void Update()
    {
        base.Update(); 
        if(tsm == null)
        {
            tsm = GameObject.FindGameObjectWithTag("TSM").GetComponent<TileStateMachine>();
            //if the tilestatemachine is not found within the start function, it will continue searching untill it finds it. 
        }
    }



    public override void Interact()
    {
        tsm.Transition(overworld);
    }
}
