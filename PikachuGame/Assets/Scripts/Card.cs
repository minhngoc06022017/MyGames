using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour
{
    private int positionX;
    private int positionY;

    public int PositionX
    {
        get
        {
            return positionX;
        }
        set
        {
            positionX = value;
        }
    }
    public int PositionY
    {
        get
        {
            return positionY;
        }
        set
        {
            positionY = value;
        }
    }

    public int Value;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        //Debug.Log(name + " Clicked!");
        if(GameManager.MyInstance.card1 == null)
        {
            GameManager.MyInstance.card1 = this;
        }
        else
        {
            if (GameManager.MyInstance.card1!=this)
            {
                GameManager.MyInstance.card2 = this;
                GameManager.MyInstance.Algorithm();
            }
        }
    }
}
