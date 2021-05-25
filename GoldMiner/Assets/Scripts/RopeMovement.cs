using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeMovement : MonoBehaviour
{
    public float min_Z = -55f, max_Z = 55f;
    public float rotate_Speed = 5f;

    private float rotate_Angle;
    private bool rotate_Right;
    private bool canRotate;

    public float move_Speed = 3f;
    private float initial_Move_Speed;

    public float min_Y = -2.5f;
    private float initial_Y;

    public bool moveDown;

    public float amountTemp;
    public float goldAmount;

    private RopeRenderer ropeRenderer;
    
    void Awake()
    {
        ropeRenderer = GetComponent<RopeRenderer>();
        initial_Y = transform.position.y;
    }

    void Start()
    {
        
        initial_Move_Speed = move_Speed;
        canRotate = true;
        moveDown = false;
        goldAmount = 0;
    }

    
    void Update()
    {
        Rotate();
        GetInput();
        MoveRope();
    }

    private void Rotate()
    {
        if (!canRotate) return;

        if (rotate_Right)
        {
            rotate_Angle += rotate_Speed * Time.deltaTime;
        }
        else
        {
            rotate_Angle -= rotate_Speed * Time.deltaTime;
        }

        transform.rotation = Quaternion.AngleAxis(rotate_Angle, Vector3.forward);

        if(rotate_Angle >= max_Z)
        {
            rotate_Right = false;
        }else if(rotate_Angle <= min_Z)
        {
            rotate_Right = true;
        }


    }
    private void GetInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (canRotate)
            {
                canRotate = false;
                moveDown = true;
            }
        }
    }
    private void MoveRope()
    {
        if (canRotate) return;

        if (!canRotate)
        {
            Vector3 temp = transform.position;

            if (moveDown)
            {
                temp -= transform.up * Time.deltaTime * move_Speed;
            }
            else
            {
                temp += transform.up * Time.deltaTime * move_Speed;
            }

            transform.position = temp;

            ropeRenderer.RenderLine(temp, true);

            if (temp.y <= min_Y)
            {
                moveDown = false;
            }
            if(temp.y >= initial_Y)
            {
                canRotate = true;

                Debug.Log("run");

                ropeRenderer.RenderLine(Vector3.zero, false);

                move_Speed = initial_Move_Speed;

                if (amountTemp > 0)
                {
                    goldAmount += amountTemp;
                    amountTemp = 0;
                    Debug.Log(goldAmount);
                }
            }

            
        }
    }
    
}
