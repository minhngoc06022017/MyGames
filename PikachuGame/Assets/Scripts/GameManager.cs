using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager MyInstance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }

    public GameObject[] Objectprefabs;

    private int[,] array =
       {{-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
        {-1,2,1,4,0,0,1,3,0,-1},
        {-1,1,2,1,4,1,2,4,1,-1},
        {-1,2,0,2,1,2,3,0,2,-1},
        {-1,3,4,1,4,3,0,2,3,-1},
        {-1,4,4,0,1,3,4,1,4,-1},
        {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1}};

    private Vector3 offset;

    public Transform spawnPosition;

    public Card card1;
    public Card card2;

    void Start()
    {

        //Debug.Log(array.GetLength(0));//row
        //Debug.Log(array.GetLength(1));//columms

        showCard();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //y is Columm=> positionX is Columm
    //x is Row=> positionY is Row
    void showCard()
    {
        offset = Vector3.zero;

        for (int x=1; x< array.GetLength(0)-1; x++)
        {
            for (int y = 1; y < array.GetLength(1)-1; y++)
            {
                offset.x = (1 * y);
                GameObject o=Instantiate(Objectprefabs[array[x, y]], spawnPosition.position + offset, Quaternion.identity) as GameObject;
                Card c = o.GetComponent<Card>();
                c.PositionX = y;
                c.PositionY = x;
                c.Value = array[x, y];


            }

            offset.y -= 1;
        }
    }

    //y is Columm=> positionX is Columm
    //x is Row=> positionY is Row
    public void Algorithm()
    {
        if(card1.Value == card2.Value)
        {

            if (checkTwoPoint(card1, card2, card1.Value))
            {
                array[card1.PositionY, card1.PositionX] = -1;
                Destroy(card1.gameObject);

                array[card2.PositionY, card2.PositionX] = -1;
                Destroy(card2.gameObject);
            }
        }

        if (CheckComplete()) Debug.Log("Win");

        card1 = null;
        card2 = null;
    }

    public bool CheckComplete()
    {
        for (int x = 0; x < array.GetLength(0); x++)
        {
            for (int y = 0; y < array.GetLength(1); y++)
            {
                if(array[x, y] != -1)
                {
                    return false;
                }
            }
        }

        return true;
    }

    //y is Columm=> positionX is Columm
    //x is Row=> positionY is Row
    private bool checkTwoPoint(Card p1, Card p2 , int value)
    {
        // check line with x
        if (p1.PositionX == p2.PositionX)
        {
            if (checkLineX(p1.PositionY, p2.PositionY, p1.PositionX, value))
            {
                return true;
            }
        }
        // check line with y
        if (p1.PositionY == p2.PositionY)
        {
            if (checkLineY(p1.PositionX, p2.PositionX, p1.PositionY, value))
            {
                return true;
            }
        }

        if (checkRectX(card1, card2, value))
        {
            return true;
        }
        if (checkRectY(card1, card2, value))
        {
            return true;
        }
        // check more right
        if (checkMoreLineX(p1, p2, 1,value))
        {
            return true;
        }
        // check more left
        if (checkMoreLineX(p1, p2, -1,value))
        {
            return true;
        }
        // check more down
        if (checkMoreLineY(p1, p2, 1,value))
        {
            return true;
        }
        // check more up
        if (checkMoreLineY(p1, p2, -1,value))
        {
            return true;
        }

        return false;
    }

    private bool checkLineX(int y1, int y2,int x,int value)
    {
        //x Columm,y Row
        
        // find point have column max and min
        int min, max;
        if (y1 > y2)
        {
            min = y2;
            max = y1;
        }
        else
        {
            min = y1;
            max = y2;
        }
        // run column
        for (int y = min; y <= max; y++)
        {
            if (array[y,x] != -1 && array[y,x]!=value)
            {
                return false;
            }
            
        }
        // not die -> success
        return true;
    }

    private bool checkLineY(int x1, int x2, int y , int value)
    {
        
        //x Columm,y Row
        int min, max;
        if (x1 > x2)
        {
            min = x2;
            max = x1;
        }
        else
        {
            min = x1;
            max = x2;
        }
        for (int x = min; x <= max; x++)
        {
            
            if (array[y,x] != -1 && array[y,x] != value)
            {
                return false;
            }
        }
        return true;
    }


    //Z line
    //y is Columm=> positionX is Columm
    //x is Row=> positionY is Row
    private bool checkRectX(Card p1, Card p2, int value)
    {
        // find point have y min and max
        Debug.Log("RectX");
        Card pMinY = p1; 
        Card pMaxY = p2;
        if (p1.PositionX > p2.PositionX)
        {
            pMinY = p2;
            pMaxY = p1;
        }
        for (int y = pMinY.PositionX + 1; y < pMaxY.PositionX; y++)
        {
            // check three line
            if (checkLineY(pMinY.PositionX, y, pMinY.PositionY,value)
                    && checkLineX(pMinY.PositionY, pMaxY.PositionY, y,value)
                    && checkLineY(y, pMaxY.PositionX, pMaxY.PositionY,value))
            {

                
                return true;
            }
        }
        // have a line in three line not true then return -1
        return false;
    }

    //y is Columm=> PositionX is Columm
    //x is Row=> PositionY is Row
    private bool checkRectY(Card p1, Card p2, int value)
    {
        Debug.Log("RectY");
        // find point have y min
        Card pMinX = p1;
        Card pMaxX = p2;
        if (p1.PositionY > p2.PositionY)
        {
            pMinX = p2;
            pMaxX = p1;
        }

        // find line and y begin
        for (int x = pMinX.PositionY + 1; x < pMaxX.PositionY; x++)
        {
            if (checkLineX(pMinX.PositionY, x, pMinX.PositionX, value)
                    && checkLineY(pMinX.PositionX, pMaxX.PositionX, x,value)
                    && checkLineX(x, pMaxX.PositionY, pMaxX.PositionX, value))
            {

                return true;
            }
        }
        return false;
    }


    //y is Columm=> PositionX is Columm
    //x is Row=> PositionY is Row
    private bool checkMoreLineX(Card p1, Card p2, int type, int value)
    {
        Debug.Log("CheckMoreLineX");
        // find point have y min
        Card pMinY = p1; 
        Card pMaxY = p2;
        if (p1.PositionX > p2.PositionX)
        {
            pMinY = p2;
            pMaxY = p1;
        }
        // find line and y begin
        int y = pMaxY.PositionX;
        int row = pMinY.PositionY;
        if (type == -1)
        {
            y = pMinY.PositionX;
            row = pMaxY.PositionY;
        }
        // check more
        if (checkLineY(pMinY.PositionX, pMaxY.PositionX, row,value))
        {
            Debug.Log("OK");
            while ((array[pMinY.PositionY,y] == -1 || array[pMinY.PositionY,y] == value)
                    && (array[pMaxY.PositionY,y] == -1 || array[pMaxY.PositionY,y] == value))
            {
                if (checkLineX(pMinY.PositionY, pMaxY.PositionY, y, value))
                {
                    return true;
                }
                y += type;
            }
        }
        return false;
    }

    //y is Columm=> PositionX is Columm
    //x is Row=> PositionY is Row
    private bool checkMoreLineY(Card p1, Card p2, int type, int value)
    {
        Debug.Log("CheckMoreLineY");
        Card pMinX = p1; 
        Card pMaxX = p2;
        if (p1.PositionY > p2.PositionY)
        {
            pMinX = p2;
            pMaxX = p1;
        }
        int x = pMaxX.PositionY;
        int col = pMinX.PositionX;
        if (type == -1)
        {
            x = pMinX.PositionY;
            col = pMaxX.PositionX;
        }
        if (checkLineX(pMinX.PositionY, pMaxX.PositionY, col,value))
        {
            while ((array[x,pMinX.PositionX] == -1 || array[x, pMinX.PositionX] == value)
                    && (array[x,pMaxX.PositionY] == -1 || array[x, pMinX.PositionX] == value))
            {
                if (checkLineY(pMinX.PositionX, pMaxX.PositionX, x,value))
                {
                    return true;
                }
                x += type;
            }
        }
        return false;
    }

}
