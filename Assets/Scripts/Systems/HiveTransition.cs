using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiveTransition : MonoBehaviour
{
    [SerializeField]
    private GameObject overworld, hive;
    [SerializeField]
    private Camera overworldCam, hiveCam;
    private bool inHive;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Transition(!inHive);
        }
    }
    public void Transition(bool into)
    {
            overworld.SetActive(!into);
            hive.SetActive(into);
            overworldCam.enabled = !into;
            hiveCam.enabled = into;
            inHive= into;
    }
}
