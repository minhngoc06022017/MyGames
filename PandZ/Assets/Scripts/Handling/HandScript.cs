using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HandScript : MonoBehaviour
{
    private static HandScript instance;
    public static HandScript MyInstance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<HandScript>();
            }
            return instance;
        }
    }

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

    private SpriteRenderer mySpriteRenderer;

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

    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        if (!IsEmpty)
        {
            mySpriteRenderer.sprite = myItem.GetComponent<SpriteRenderer>().sprite;


            Vector3 camPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(camPosition.x,camPosition.y,0);
        }
        else
        {
            mySpriteRenderer.sprite = null;
        }
    }
}
