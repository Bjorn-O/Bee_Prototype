using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeManager : MonoBehaviour
{
    [SerializeField]
    private int totalBees, busyBees, freeBees;


    private void Start()
    {
        freeBees = totalBees;
    }
    public bool AssignBees(int number)
    {
        Debug.Log("Adding bees");
        if(freeBees >= number)
        {
            freeBees -= number;
            busyBees += number;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Freebees(int number)
    {
        if((freeBees + number ) + (busyBees - number) == totalBees)
        {
            busyBees -= number;
            freeBees += number;
        }
    }

    public void AddTotalBees(int number)
    {
        totalBees += number;
        freeBees += number;
    }
}
