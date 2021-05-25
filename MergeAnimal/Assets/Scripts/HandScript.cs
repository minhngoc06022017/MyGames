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
    private Pet myItem;
    public Pet MyItem
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

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (myItem != null)
        {
            GetComponent<SpriteRenderer>().sprite = myItem.gameObject.GetComponent<SpriteRenderer>().sprite;

            Vector3 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePoint.x, mousePoint.y, 0);
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = null;
        }
    }
}
