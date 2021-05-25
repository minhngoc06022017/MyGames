using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeBlock : MonoBehaviour
{
    [SerializeField]
    private float correctAngle;

    [SerializeField]
    private bool typeI;

    [SerializeField]
    private float initialAngle;

    [SerializeField]
    private Transform pointPosition;
    public Transform PointPosition
    {
        get
        {
            return pointPosition;
        }
    }

    private bool done;
    public bool Done
    {
        get
        {
            return done;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //transform.eulerAngles.z = initialAngle;
        checkAngle();

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        transform.eulerAngles -= new Vector3(0, 0, 90);

        checkAngle();
    }

    void checkAngle()
    { 
        if (typeI)
        {
            if(transform.eulerAngles.z == 180)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }

        if (transform.eulerAngles.z == correctAngle)
        {
            done = true;
        }
        else
        {
            done = false;
        }
    }
}
