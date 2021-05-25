using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField]
    private float correctAngle;

    [SerializeField]
    private float initialAngle;

    private int[] angles = new int[] { 0, 90, 180, 270 };

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
        int ran = Random.Range(0, 4);
        transform.eulerAngles += new Vector3(0,0, angles[ran]);
        checkAngle();


    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        transform.eulerAngles += new Vector3(0, 0, 90);

        checkAngle();
    }

    void checkAngle()
    {
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
