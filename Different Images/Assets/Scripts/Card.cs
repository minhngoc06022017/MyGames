using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField]
    private Point[] points;
    public Point[] MyPoints
    {
        get
        {
            return points;
        }
    }

    [SerializeField]
    private GameObject image;

    [SerializeField]
    private GameObject buttons;

    public bool IsDone;

    public bool IsFull
    {
        get
        {
            for(int i=0;i< points.Length; i++)
            {
                if (!points[i].isClick) return false;
            }

            return true;
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void checkComplete()
    {
        if (IsFull)
        {
            IsDone = true;
            GameManager.Instance.NextMap(points.Length);
            image.SetActive(false);
            buttons.SetActive(false);
        }
    }
}
