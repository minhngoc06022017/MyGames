using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Point : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isClick;

    [SerializeField]
    private Card myCard;

    [SerializeField]
    private Image myImage;

    [SerializeField]
    private Image sameImage;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Click()
    {
        if (!isClick)
        {
            isClick = true;
            myImage.enabled = true;
            sameImage.enabled = true;

            myCard.checkComplete();
        }
    }
}
