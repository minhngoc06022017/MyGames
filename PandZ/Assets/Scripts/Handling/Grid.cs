using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer myEmptySprite;

    [SerializeField]
    private GameObject myItem;
    public GameObject MyItem
    {
        get
        {
            return myItem;
        }
        set
        {
            myItem = value;
        }
    }
    public bool IsEmpty
    {
        get
        {
            if (myItem == null)
            {
                return true;
            }

            return false;
        }
    }
    private bool runOver=true;
    [SerializeField]
    private Color myInitialColor;

    void Start()
    {
        myInitialColor = GetComponent<SpriteRenderer>().color;
    }


    void Update()
    {

    }

    public void OnMouseDown()
    {
        if (!IsEmpty)
        {
            if (!HandScript.MyInstance.IsEmpty && HandScript.MyInstance.MyItem.name == "Shovel")
            {
                Destroy(myItem);
                myItem = null;
                HandScript.MyInstance.MyItem = null;
                runOver = false;
                return;
            }
        }

        if (IsEmpty && !HandScript.MyInstance.IsEmpty && !HandScript.MyInstance.MyItem.name.Equals("Shovel"))
        {
            myItem = Instantiate(HandScript.MyInstance.MyItem, transform.position, Quaternion.identity);
            HandScript.MyInstance.MyItem = null;

            myEmptySprite.sprite = null;

            Color tmp = myEmptySprite.color;
            tmp.a = 0f;
            myEmptySprite.color = tmp;
        }
        
    }
    public void OnMouseOver()
    {
        if (runOver)
        {
            if (!HandScript.MyInstance.IsEmpty && !HandScript.MyInstance.MyItem.name.Equals("Shovel"))
            {
                if (IsEmpty)
                {
                    if (!HandScript.MyInstance.IsEmpty)
                    {
                        myEmptySprite.sprite = HandScript.MyInstance.MyItem.GetComponent<SpriteRenderer>().sprite;

                        Color tmp = myEmptySprite.color;
                        tmp.a = 0.5f;
                        myEmptySprite.color = tmp;
                    }
                }
                else
                {
                    GetComponent<SpriteRenderer>().color = Color.red;
                }
            }
        }
    }
    public void OnMouseExit()
    {
        if (!HandScript.MyInstance.IsEmpty)
        {
            if (IsEmpty)
            {
                myEmptySprite.sprite = null;

                Color tmp = myEmptySprite.color;
                tmp.a = 0f;
                myEmptySprite.color = tmp;
            }
            else
            {
                GetComponent<SpriteRenderer>().color = myInitialColor;
            }
        }

        runOver = true;
    }


}
