using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PieceScript : MonoBehaviour
{
    private Vector3 rightPosition;
    public bool isRightPosition;
    public bool isSelected;
    
    void Start()
    {
        rightPosition = transform.position;
        transform.position = new Vector3(Random.Range(0, 4.5f), Random.Range(3.5f, -1.5f));
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position,rightPosition) < 0.5f)
        {
            if (!isSelected)
            {
                if (!isRightPosition)
                {
                    transform.position = rightPosition;
                    isRightPosition = true;
                    //GetComponent<SortingLayer>().sortingOrder = 0;
                }
            }
        }
    }
}
