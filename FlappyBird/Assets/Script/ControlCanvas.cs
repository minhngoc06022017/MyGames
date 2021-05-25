using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCanvas : MonoBehaviour
{
    public GameObject control;
    public bool isPause = false;
    
    void Start()
    {
        control.SetActive(isPause);
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPause = !isPause;
        }
        if (isPause)
        {
            control.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            control.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
