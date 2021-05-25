using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetUI : MonoBehaviour
{
    public Timing timing;

    public float MyTime;

    public bool run;

    public GameObject timingObject;

    void Awake()
    {
        
    }

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (run)
        {
            if(timing.MyCurrentValue <= MyTime)
            {
                timing.MyCurrentValue += Time.deltaTime;
                //Debug.Log(timing.IsFull);
            } 
        }
        
    }

    public void Active()
    {
        timingObject.SetActive(true);
        timing.Initialize(0,MyTime);
        run = true;
    }
}
