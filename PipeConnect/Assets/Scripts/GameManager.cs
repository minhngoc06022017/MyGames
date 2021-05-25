using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private PipeBlock[] collections;

    private List<Vector3> Points;

    private int index;

    private bool ballRun;

    [SerializeField]
    private Transform ball;
    [SerializeField]
    private float speedBall;

    void Start()
    {
        Points = new List<Vector3>();

        index = 0;

        foreach (PipeBlock p in collections)
        {
            Points.Add(p.PointPosition.position);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (checkWin())
        {
            ballRun = true;

        }
        if (ballRun)
        {
            Vector3 temp = Points[index];

            ball.position = Vector3.MoveTowards(ball.position, temp, speedBall * Time.deltaTime);

            if (ball.position == temp)
            {
                index++;
            }

            if (index == Points.Count-1)
            {
                ballRun = false;
            }
        }

    }

   

    private bool checkWin()
    {
        foreach(PipeBlock p in collections)
        {
            if (!p.Done)
            {
                
                return false;
            }
        }
        return true;
    }
}
