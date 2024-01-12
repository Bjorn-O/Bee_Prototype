using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Rubble : GridObject
{
    [SerializeField]
    private float timeToClear;
    [SerializeField]
    private GameObject constructionModel = null; 
    private TileStateMachine tsm;
    protected override void Start()
    {
        base.Start();
        tsm = GameObject.FindGameObjectWithTag("TSM").GetComponent<TileStateMachine>();
    }

    protected override void Update()
    {
        base.Update();
        if (tsm == null)
        {
            tsm = GameObject.FindGameObjectWithTag("TSM").GetComponent<TileStateMachine>();
            //if the tilestatemachine is not found within the start function, it will continue searching untill it finds it. 
        }
    }

    public override void Interact()
    {
        tsm.StartConstruction(this.gameObject, timeToClear, constructionModel != null ? constructionModel: null);
    }
}
