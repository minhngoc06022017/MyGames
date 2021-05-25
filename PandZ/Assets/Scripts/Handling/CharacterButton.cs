using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterButton : MonoBehaviour
{
    [SerializeField]
    private GameObject myItem;

    [SerializeField]
    private Image mySprite;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (myItem != null)
        {
            mySprite.sprite = myItem.GetComponent<SpriteRenderer>().sprite;
        }
        else
        {
            mySprite.sprite = null;

            Color tmp = mySprite.color;
            tmp.a = 0f;
            mySprite.color = tmp;
        }
    }

    public void OnClick()
    {
        if (HandScript.MyInstance.IsEmpty && myItem!=null)
        {
            HandScript.MyInstance.MyItem = myItem;
        }
    }
}
