using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClearRubble : MonoBehaviour
{

    private BeeManager bm;
    private float startTime, timeRemaining, speed;
    private GameObject rubble;
    [SerializeField]
    private int bees;
    private bool timer;
    [SerializeField]
    private TextMeshProUGUI time;
    [SerializeField]
    private Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        bm = GameObject.FindGameObjectWithTag("BM").GetComponent<BeeManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if (bm == null)
        {
            bm = GameObject.FindGameObjectWithTag("BM").GetComponent<BeeManager>();
            AddBee();
        }
        if (timer)
        {
            timeRemaining -= Time.deltaTime * speed;
            if (timeRemaining < 0)
            {

            }
        }
        speed = 0.1f * bees;
        slider.value = (timeRemaining * speed) / startTime;
        time.text = timeRemaining * speed > 60 ? timeRemaining * speed + " Minutes remain" : timeRemaining * speed + " Seconds remain";
    }

    public void StartTimer(float Time, GameObject obj)
    {
        startTime = Time;
        timer = true;
        timeRemaining = Time;
        rubble = obj;
        AddBee();
    }
    public void AddBee()
    {
        if (bm.AssignBees(1))
        {
            bees++;
        }
    }
    public void RemoveBee()
    {
        if (bees > 0)
        {
            bm.Freebees(1);
        }
    }
    private void EndTimer()
    {
        bm.Freebees(bees);

    }
}
